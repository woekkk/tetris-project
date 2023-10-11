﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisTemplate
{
    class BlockZ : TetrisBlock
    {
        public override bool[,] shape { get; set; }
        public override Color color { get; set; }

        public BlockZ() : base(3)
        {
            shape = new bool[3, 3];
            color = Color.Tomato;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((j == 0 && i != 2) || (j == 1 && i != 0))
                        shape[i, j] = true;
                    else
                        shape[i, j] = false;
                }
            }
        }
    }
}