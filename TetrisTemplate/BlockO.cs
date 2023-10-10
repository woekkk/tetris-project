using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisTemplate
{
    class BlockO : TetrisBlock
    {
        public override bool[,] shape { get; set; }

        public BlockO() : base(2)
        {
            shape = new bool[2,2];
            shape[0,0] = true;
            shape[1,0] = true;
            shape[0,1] = true;
            shape[1,1] = true;
        }
    }
}
