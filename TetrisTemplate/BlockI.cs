using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TetrisTemplate
{
    class BlockI : TetrisBlock
    {
        protected BlockI(bool[,] shape) : base(shape)
        {
            shape = new bool[4, 4];
        }
    }
}
