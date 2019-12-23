using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenMOO2Viewer
{
    public struct LBXHeader
    {
        public ushort blockCount;
        public ushort signature;
        public ushort reserved;
        public ushort version;
    };

    [Flags]
    public enum ImageFlags : ushort
    {
        NO_COMPRESSION = 0x0100,
        FILL_BACKGROUND = 0x0400,
        FUNCTIONAL_COLOR = 0x0800,
        INTERNAL_PALETTE = 0x1000,
        JUNCTION = 0x2000
    };

    class LBXReader
    {
        private BinaryReader _fileIn;
        private string _filePath;
        private int _blockCount;
        private int[] _blockSizes;
        private int[] _blockOffsets;


        public LBXReader()
        {
            //
        }

        public LBXReader(string filePath)
        {
            open(filePath);
        }

        ~LBXReader()
        {
            close();
        }

        // open an LBX file and load/compute the offsets/sizes for each block
        public void open(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            _fileIn = new BinaryReader(File.Open(filePath, FileMode.Open));

            LBXHeader header;
            header.blockCount = _fileIn.ReadUInt16();
            header.signature = _fileIn.ReadUInt16();
            header.reserved = _fileIn.ReadUInt16();
            header.version = _fileIn.ReadUInt16();

            // magic signature value
            if (header.signature != 0xFEAD)
            {
                _fileIn.Close();
                throw new Exception("Invalid LBX signature.");
            }
            // a version of 0 seems to be specific to MOO2
            else if (header.version != 0)
            {
                _fileIn.Close();
                throw new Exception("Not a valid Master of Orion 2 LBX file.");
            }
            else
            {
                _filePath = filePath;
                _blockSizes = new int[header.blockCount];
                _blockOffsets = new int[header.blockCount];
                _blockCount = header.blockCount;

                // if blockCount is N, there are N+1 offsets to read
                int start, end;

                // typically 0x0800 for MOO2 LBX files
                start = _fileIn.ReadInt32();

                for (short i = 0; i < header.blockCount; i++)
                {
                    end = _fileIn.ReadInt32();
                    _blockSizes[i] = end - start;
                    _blockOffsets[i] = start;
                    start = end;
                }
            }
        }

        // read a block of the given index from the current LBX file into to the given LBXBlock object
        public void read(LBXBlock block, int index)
        {
            if (_fileIn != null)
            {
                if (index < _blockCount)
                {
                    // some LBX files have 0-length blocks, so check for that
                    if (_blockSizes[index] > 0)
                    {
                        _fileIn.BaseStream.Position = _blockOffsets[index];
                        block.data = _fileIn.ReadBytes(_blockSizes[index]);
                    }
                    else
                        block.data = null;

                    block.filePath = _filePath;
                    block.index = index;
                    block.offset = _blockOffsets[index];
                    block.size = _blockSizes[index];
                }
                else
                    throw new IndexOutOfRangeException("Requested block index out of bounds.");
            }
            else
                throw new Exception("No LBX file opened.");
        }

        public void close()
        {
            if (_fileIn != null)
                _fileIn.Close();
            _fileIn = null;
            _filePath = "";
            _blockCount = 0;
            _blockSizes = null;
            _blockOffsets = null;
        }

        // lol getters?
        public int getBlockSize(int index)
        {
            if (_fileIn != null && index < _blockCount)
                return _blockSizes[index];
            else
                return 0;
        }

        public int getBlockOffset(int index)
        {
            if (_fileIn != null && index < _blockCount)
                return _blockOffsets[index];
            else
                return 0;
        }

        public int getBlockCount()
        {
            if (_fileIn != null)
                return _blockCount;
            else
                return 0;
        }

        public long getFileSize()
        {
            if (_fileIn != null)
            {
                if (_fileIn.BaseStream != null)
                    return _fileIn.BaseStream.Length;
                else
                    return 0;
            }
            else
                return 0;
        }
    }
}
