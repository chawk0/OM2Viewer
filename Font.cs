using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace OpenMOO2Viewer
{
    class Font
    {
        //private byte[] _glyphWidths;
        //private byte[] _glyphHeights;
        //private uint[] _glyphOffsets;
        //private uint[] _glyphDataSize;
        private byte[][,] _glyphData;
        private byte[] _glyphColors;
        private int _maxGlyphWidth;
        private int _maxGlyphHeight;

        private Palette _palette;

        public Palette palette
        {
            get
            {
                return _palette;
            }

            set
            {
                if (value != null)
                    _palette = value;
            }
        }

        public byte[] glyphColors
        {
            get
            {
                return this._glyphColors;
            }
        }

        public int maxGlyphWidth
        {
            get
            {
                return _maxGlyphWidth;
            }
        }

        public int maxGlyphHeight
        {
            get
            {
                return _maxGlyphHeight;
            }
        }

        public Font()
        {
            //
        }
        
        public int getGlyphWidth(int index)
        {
            if (index > 0 && index < 256)
                if (this._glyphData[index] != null)
                    return this._glyphData[index].GetLength(0);
                else
                    return 0;
            else
                throw new ArgumentOutOfRangeException("Glyph index out of bounds.");
        }

        public int getGlyphHeight(int index)
        {
            if (index > 0 && index < 256)
                if (this._glyphData[index] != null)
                    return this._glyphData[index].GetLength(1);
                else
                    return 0;
            else
                throw new ArgumentOutOfRangeException("Glyph index out of bounds.");
        }

        /// <summary>
        /// Loads a particular font (out of 6) from the given block.
        /// </summary>
        /// <param name="block"></param>
        /// <param name="index"></param>
        public void load(LBXBlock block, int index)
        {
            if (block == null || index < 0 || index > 5)
                throw new Exception("Invalid font load parameters.");
            else if (block.data == null)
                throw new Exception("Font block data is null");
            else
            {
                // I love these things.
                BinaryReader data = new BinaryReader(new MemoryStream(block.data));
                
                // jump to the start of font[index]'s glyph widths;
                // 256 glyphs, 1 byte per width, total of 0x100 bytes per font
                data.BaseStream.Position = 0x59C + (long)index * 0x100;

                byte[] glyphWidths = new byte[256];
                this._maxGlyphWidth = 0;

                // read the widths
                for (int i = 0; i < 256; ++i)
                {
                    glyphWidths[i] = data.ReadByte();

                    if (glyphWidths[i] > this._maxGlyphWidth)
                        this._maxGlyphWidth = glyphWidths[i];
                }

                // jump to the start of font[index]'s glyph offsets;
                // 256 glyphs, 4 bytes per offset, total of 0x400 bytes per font
                data.BaseStream.Position = 0xB9C + (long)index * 0x400;

                uint[] glyphOffsets = new uint[256];
                uint[] glyphDataSize = new uint[256];

                // read the offsets
                for (int i = 0; i < 256; ++i)
                {
                    glyphOffsets[i] = data.ReadUInt32();

                    // compute the data size as the difference between offsets
                    if (i > 0)
                        glyphDataSize[i - 1] = glyphOffsets[i] - glyphOffsets[i - 1];
                }

                // don't forget the last glyphDataSize
                //glyphDataSize[255] = data.ReadUInt32() - glyphOffsets[255];
                glyphDataSize[255] = 0;

                // the max glyph width is used to generate the temporary buffer into which
                // font data is decoded.  it's assumed no glyph would be taller than twice
                // the max width, but this isn't necessarily so.
                byte[,] glyphBuffer = new byte[maxGlyphWidth, maxGlyphWidth * 2];

                int cx, cy;
                int maxW, maxH;

                // jagged array of 2D arrays, mmmm.
                this._glyphData = new byte[256][,];
                // this will track the distinct palette indices that this font uses
                this._glyphColors = new byte[256];

                this._maxGlyphHeight = 0;

                // read in the font data!
                for (int i = 0; i < 256; ++i)
                {
                    // all 6 fonts' offsets are relative to the start of the font data at 0x239C
                    data.BaseStream.Position = 0x239C + glyphOffsets[i];

                    cx = 0;
                    cy = 0;
                    maxW = 0;
                    maxH = 0;
                    //Array.Clear(glyphBuffer, 0, glyphBuffer.Length);
                    for (int y = 0; y < glyphBuffer.GetLength(1); ++y)
                        for (int x = 0; x < glyphBuffer.GetLength(0); ++x)
                            glyphBuffer[x, y] = 0xFF;

                    try
                    {
                        while ((data.BaseStream.Position - 0x239C - glyphOffsets[i]) < glyphDataSize[i])
                        {
                            byte val = data.ReadByte();

                            // 0x00-0x7f: color of next pixel
                            if (val <= 0x7F)
                            {
                                if (this._glyphColors[val] == 0)
                                    this._glyphColors[val]++;

                                if (cx >= 0 && cx < glyphBuffer.GetLength(0) &&
                                    cy >= 0 && cy < glyphBuffer.GetLength(1))
                                {
                                    glyphBuffer[cx, cy] = val;

                                    // track the total pixel-drawing extent of this glyph
                                    if (cx > maxW)
                                        maxW = cx;
                                    if (cy > maxH)
                                        maxH = cy;

                                    // increment after tracking!
                                    cx++;
                                }
                            }
                            // 0x80: skip to beginning of next line
                            else if (val == 0x80)
                            {
                                cx = 0;
                                cy++;
                            }
                            // 0x8n: skip n pixels
                            else
                            {
                                cx += (val & 0x0F);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //
                    }

                    // now allocate the properly sized mini-buffer for this glyph and copy from the temp buffer
                    if (true)//maxW > 0 && maxH > 0)
                    {
                        this._glyphData[i] = new byte[maxW + 1, maxH + 1];

                        for (int x = 0; x < (maxW + 1); ++x)
                            for (int y = 0; y < (maxH + 1); ++y)
                                this._glyphData[i][x, y] = glyphBuffer[x, y];

                        // track the max glyph height
                        if ((maxH + 1) > this._maxGlyphHeight)
                            this._maxGlyphHeight = maxH + 1;
                    }
                }
            }
        }

        public void renderGlyph(byte glyph, Bitmap bitmap, int x, int y)
        {
            // make sure the glyph actually has some pixel data and that we have a palette
            if (this._glyphData[glyph] != null && this._palette != null)
            {
                for (int yy = 0; yy < this._glyphData[glyph].GetLength(1); ++yy)
                {
                    for (int xx = 0; xx < this._glyphData[glyph].GetLength(0); ++xx)
                    {
                        byte val = this._glyphData[glyph][xx, yy];
                        //if (val != 0xFF)
                        //{
                            Color color = Color.FromArgb((int)this._palette[val]);
                            bitmap.SetPixel(x + xx, y + yy, color);
                        //}
                    }
                }
            }
        }

        public void renderString(string s, Bitmap bitmap, int x, int y)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(s);

            int cx = x;
            int cy = y;

            for (int i = 0; i < bytes.Length; ++i)
            {
                this.renderGlyph(bytes[i], bitmap, cx, cy);
                cx += (this.getGlyphWidth(bytes[i]) + 1);
            }
        }
    }
}
