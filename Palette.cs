using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace OpenMOO2Viewer
{
    class Palette
    {
        private uint[] _palette;

        // these fields allow the palette to represent a partial palette of less than 256 colors;
        // the offset represents where in a full 256-color palette the partial palette begins;
        // size is the number of palette entries in a partial palette
        public int size { get; private set; }
        public int offset { get; private set; }

        public Palette()
        {
            this._palette = new uint[256];
        }

        /// <summary>
        /// Copy constructor!
        /// </summary>
        /// <param name="p"></param>
        public Palette(Palette p)
            : this()
        {
            for (int i = 0; i < p.size; ++i)
                this._palette[i + p.offset] = p[i + p.offset];
            this.size = p.size;
            this.offset = p.offset;
        }


        /// <summary>
        /// Load a full 256-entry palette from a given LBX file and block index.
        /// </summary>
        /// <param name="filePath">Full file path to the LBX file</param>
        /// <param name="index">Zero-based block index</param>
        public void load(string filePath, int index)
        {
            LBXReader lbx = new LBXReader(filePath);
            LBXBlock block = new LBXBlock();

            lbx.read(block, index);
            load(block);
            lbx.close();
        }

        /// <summary>
        /// Load a full 256-entry palette from the data contained in the given LBXBlock.
        /// </summary>
        /// <param name="block"></param>
        public void load(LBXBlock block)
        {
            if (block != null)
            {
                for (int i = 0; i < 256; ++i)
                {
                    /*
                    // convert ARGB [0,63] to RGBA [0,255]
                    uint color = ((uint)block.data[i * 4 + 1] << 2) +
                                 ((uint)block.data[i * 4 + 2] << 10) +
                                 ((uint)block.data[i * 4 + 3] << 18) +
                                 ((uint)block.data[i * 4 + 0] << 24);
                     * */
                    // convert ARGB [0,63] to ARGB [0,255]
                    uint a = (uint)block.data[i * 4 + 0];
                    uint r = (uint)block.data[i * 4 + 1] << 2;
                    uint g = (uint)block.data[i * 4 + 2] << 2;
                    uint b = (uint)block.data[i * 4 + 3] << 2;

                    //if (a == 1)
                        a = 255;

                    //_palette[i] = r + (g << 8) + (b << 16) + (a << 24);
                    // BGRA ????????

                    this._palette[i] = b + (g << 8) + (r << 16) + (a << 24);
                }

                this.size = 256;
                this.offset = 0;
            }
            else
                throw new Exception("Null block given to load");
        }

        /// <summary>
        /// Load a (possibly partial) palette from a uint array and an offset.
        /// </summary>
        /// <param name="p"></param>
        public void load(uint[] p, int o)
        {
            // sanitize that input!
            if (p != null)
            {
                // more sanitation
                if (p.Length > 0 && p.Length <= 256 && (p.Length + o) <= 256 && o >= 0 && o < 256)
                {
                    // allocate a fresh palette
                    this._palette = new uint[256];
                    for (int i = 0; i < p.Length; ++i)
                        this._palette[i + o] = p[i];
                    this.size = p.Length;
                    this.offset = o;
                }
                else
                    throw new Exception("Palette array and/or offset out of bounds");
            }
            else
                throw new Exception("Palette array is null");
        }

        /// <summary>
        /// Merge the given palette's colors into the calling object's, overwriting existing entries.
        /// </summary>
        /// <param name="p"></param>
        public void merge(Palette p)
        {
            for (int i = 0; i < p.size; ++i)
                this._palette[i + p.offset] = p[i + p.offset];
        }

        /*
        public void clear()
        {
            for (int i = 0; i < 256; ++i)
                _palette[i] = 0;
        }
         * */

        /*
        public Palette clone()
        {
            Palette newPalette = new Palette();

            for (uint i = 0; i < 256; ++i)
                newPalette[i] = _palette[i];

            return newPalette;
        }
         * */

        public void drawPalette(Bitmap bitmap, int size)
        {
            if (bitmap != null && size > 0)
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.Clear(Color.Black);

                /*
                // draw a 16x16 grid of palette colors into the given bitmap
                for (int y = 0; y < 16; ++y)
                {
                    for (int x = 0; x < 16; ++x)
                    {
                        Rectangle r = new Rectangle(x * size, y * size, size, size);
                        Color c = Color.FromArgb((int)_palette[x + y * 16]);
                        SolidBrush b = new SolidBrush(c);
                        g.FillRectangle(b, r);
                    }
                }
                 * */

                // draw a 16x16 grid of palette colors into the given bitmap (or partial grid)
                for (int i = 0; i < this.size; ++i)
                {
                    int x = (i + this.offset) % 16;
                    int y = (i + this.offset) / 16;

                    Rectangle r = new Rectangle(x * size, y * size, size, size);
                    Color c = Color.FromArgb((int)this._palette[i + this.offset]);
                    SolidBrush b = new SolidBrush(c);
                    g.FillRectangle(b, r);
                }
            }
            else
                throw new Exception("Invalid target bitmap and/or size.");
        }

        public uint this[int key]
        {
            get
            {
                if (key < 256)
                    return this._palette[key];
                else
                    throw new Exception("Palette index out of bounds.");
            }
            /*
            set
            {
                _palette[key] = value;
            }
             * */
        }
    }
}
