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
        public override bool[,] shape { get; set; }
        
        public BlockI() : base(4)
        {
            shape = new bool[4, 4];
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j == 1)
                        shape[i, j] = true;
                    else
                        shape[i, j] = false;
                }
            }
        }
        

    }
}
