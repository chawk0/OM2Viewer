using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMOO2Viewer
{
    class LBXBlock
    {
        public byte[] data = null;
        public int offset = 0;
        public int size = 0;
        public string filePath;
        public int index = 0;

        public enum BlockType
        {
            IMAGE,
            UNKNOWN
        }

        public static BlockType identifyBlockType()
        {
            return BlockType.IMAGE;
        }
    }
}
