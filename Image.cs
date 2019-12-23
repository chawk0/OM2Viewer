/*
	Decodes images/animations from MOO2 LBX files and renders to a buffer

	09/10/2014
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenMOO2Viewer
{
    public struct ImageHeader
    {
        public ushort width;
        public ushort height;
        public ushort zero;
        public ushort frameCount;
        public ushort frameDelay;
        public ushort flags;
    };

    public struct ImageFrame
    {
        public uint size;
        public uint offset;
        public Bitmap bitmap;
        public byte[] buffer;
    };

    class Image
    {
        private ImageHeader _header;
        private Palette _externalPalette, _internalPalette, _mixedPalette;
        private ImageFrame[] _frames;

        public Image()
        {
        }

        ~Image()
        {
            free();
        }

        public void load(string filePath, int index)
        {
            LBXReader lbx = new LBXReader(filePath);
            LBXBlock block = new LBXBlock();

            lbx.read(block, index);
            load(block);
            lbx.close();
        }

        public void load(LBXBlock block)
        {
            if (block.size > 0 && block.data != null)
            {
                free();
                BinaryReader data = new BinaryReader(new MemoryStream(block.data));

                // read header information
                _header.width = data.ReadUInt16();
                _header.height = data.ReadUInt16();
                _header.zero = data.ReadUInt16();
                _header.frameCount = data.ReadUInt16();
                _header.frameDelay = data.ReadUInt16();
                _header.flags = data.ReadUInt16();

                // only support 640x480 images for now
                if (_header.width <= 640 && _header.height <= 480)
                {
                    _frames = new ImageFrame[_header.frameCount];

                    // read frame offsets, plus the extra at the end
                    uint start, end;
                    start = data.ReadUInt32();

                    for (int i = 0; i < _header.frameCount; ++i)
                    {
                        end = data.ReadUInt32();
                        _frames[i].size = end - start;
                        _frames[i].offset = start;
                        start = end;
                    }

                    // if there's an internal palette, it follows the offsets and precedes the frame data
                    if ((_header.flags & (ushort)ImageFlags.INTERNAL_PALETTE) != 0)
                    {
                        // color shift specifies where to start overwriting the palette with colorCount colors
                        ushort colorShift = data.ReadUInt16();
                        ushort colorCount = data.ReadUInt16();

                        if (colorCount > 256 || colorShift > 255)
                            throw new Exception("Invalid internal palette");
                        else
                        {
                            uint[] buffer = new uint[colorCount];

                            for (int i = 0; i < colorCount; ++i)
                            {
                                // read in ARGB [0, 63] and save as ARGB [0, 255]
                                uint a = data.ReadByte();
                                uint r = (uint)data.ReadByte() << 2;
                                uint g = (uint)data.ReadByte() << 2;
                                uint b = (uint)data.ReadByte() << 2;

                                //if (a == 1)
                                //    a = 255;
                                //else if (a == 0)
                                a = 255;

                                uint color = b + (g << 8) + (r << 16) + (a << 24);
                                buffer[i] = color;
                            }

                            _internalPalette = new Palette();
                            _internalPalette.load(buffer, colorShift);
                            _updatePalettes();
                        }
                    }

                    // read in frame data
                    for (int f = 0; f < _frames.Length; ++f)
                    {
                        data.BaseStream.Position = _frames[f].offset;

                        // first byte of the "frame header" should be 1.
                        // if not, invalid frame! current frame's buffer remains null
                        if (data.ReadUInt16() != 1)
                        {
                            _frames[f].buffer = null;
                            _frames[f].bitmap = null;
                            continue;
                        }
                        else
                        {
                            //data.ReadUInt16();
                            //_frames[f].bitmap = new Bitmap(_header.width, _header.height);
                            _frames[f].buffer = new byte[_header.width * _header.height];
                            _frames[f].bitmap = new Bitmap(_header.width, _header.height);

                            short pixelCount, startY, xIndent, yIndent;
                            short cx = 0, cy = 0;

                            // get the starting Y position for drawing
                            startY = data.ReadInt16();
                            cy += startY;

                            // draw loop until break (yIdent == 1000) or we go beyond the frame size (shouldn't happen normally?)
                            while ((data.BaseStream.Position - _frames[f].offset) < _frames[f].size)
                            {
                                pixelCount = data.ReadInt16();

                                // if the pixel count is > 0, this is a horizontal run
                                if (pixelCount > 0)
                                {
                                    xIndent = data.ReadInt16();
                                    cx += xIndent;

                                    // copy the run of pixels
                                    data.Read(_frames[f].buffer, cx + cy * (short)_header.width, pixelCount);
                                    cx += pixelCount;

                                    // if the pixel count was odd, skip 1 extra byte!
                                    if ((pixelCount % 2) != 0)
                                        data.ReadByte();
                                }
                                // else, it's a y-indent with no drawing
                                else
                                {
                                    yIndent = data.ReadInt16();

                                    // if y-indent is 1000, it means quit?
                                    if (yIndent != 1000)
                                    {
                                        cy += yIndent;
                                        cx = 0;
                                    }
                                    else
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                    throw new Exception("image larger than 640x480 (?)");
            }
        }

        /// <summary>
        /// Renders the frames' palettized pixel data in ImageFrame.buffer to ImageFrame.bitmap
        /// </summary>
        public void render()
        {
            render(_internalPalette);
        }
        
        /// <summary>
        /// Renders the frames' palettized pixel data in ImageFrame.buffer to ImageFrame.bitmap,
        /// using the provided internal Palette, overriding any saved one.
        /// </summary>
        /// <param name="internalPalette"></param>
        public void render(Palette internalPalette)
        {
            //if (
            Palette p;
            Graphics g;
            
            // if the Image's own internal palette was passed, draw from the mixed
            if (internalPalette == _internalPalette)
                p = _mixedPalette;
            // else, build a temporary mixed palette
            else
            {
                p = new Palette(_externalPalette);
                p.merge(internalPalette);
            }

            // !
            for (int i = 0; i < _header.frameCount; ++i)
            {
                if (_frames[i].bitmap != null && _frames[i].buffer != null)
                {
                    g = Graphics.FromImage(_frames[i].bitmap);
                    g.Clear(Color.Black);

                    for (int y = 0; y < _header.height; ++y)
                    {
                        for (int x = 0; x < _header.width; ++x)
                        {
                            int index = x + y * _header.width;
                            int val = _frames[i].buffer[index];
                            _frames[i].bitmap.SetPixel(x, y, Color.FromArgb((int)p[val]));
                        }
                    }
                }
                else
                {
                    // make it some kind of "invalid" default image?
                }
            }
        }

        public void setExternalPalette(Palette palette)
        {
            _externalPalette = palette;
            _updatePalettes();
        }

        private void _updatePalettes()
        {
            if (_externalPalette != null)
            {
                if (_internalPalette != null)
                {
                    _mixedPalette = new Palette(_externalPalette);
                    _mixedPalette.merge(_internalPalette);
                }
                else
                    _mixedPalette = _externalPalette;
            }
        }

        public void free()
        {
            _header.width = 0;
            _header.height = 0;
            _header.zero = 0;
            _header.frameCount = 0;
            _header.frameDelay = 0;
            _header.flags = 0;

            // meh?
            //_externalPalette = null;
            //_internalPalette = null;
            //_mixedPalette = null;

            if (_frames != null)
            {
                for (int i = 0; i < _frames.Length; ++i)
                {
                    if (_frames[i].bitmap != null)
                        _frames[i].bitmap.Dispose();
                    _frames[i].buffer = null;
                }
            }
            _frames = null;
        }

        public int getWidth()
        {
            return _header.width;
        }

        public int getHeight()
        {
            return _header.height;
        }

        public ImageFrame[] getFrames()
        {
            return _frames;
        }

        public ImageHeader getHeader()
        {
            return _header;
        }

        public Palette getInternalPalette()
        {
            return _internalPalette;
        }

        public Palette getMixedPalette()
        {
            return _mixedPalette;
        }
    }
}
