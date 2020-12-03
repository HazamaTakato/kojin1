using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DAction
{
    static class StageMap
    {
        public const int XMax = 48;//横最大数
        public const int YMax = 12;//縦最大数
        public const int BlockSize = 64;//ブロックの大きさ

        public const int width = StageMap.XMax * StageMap.BlockSize;
    }
}
