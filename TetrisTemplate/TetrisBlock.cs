using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TetrisTemplate
{
    class TetrisBlock
    {
        public bool[,] shape;

        protected TetrisBlock(bool[,] shape)
        {
            this.shape = shape;
        }
    }
}

