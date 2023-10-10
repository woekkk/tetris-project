using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisTemplate
{
    class BlockJ : TetrisBlock
    {
        public override bool[,] shape { get; set; }

        public BlockJ() : base(3)
        {
            shape = new bool[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 1 || (j == 0 && i == 2))
                        shape[i, j] = true;
                    else
                        shape[i, j] = false;
                }
            }
        }
    }
}
