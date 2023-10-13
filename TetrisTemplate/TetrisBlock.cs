using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TetrisTemplate
{
    abstract class TetrisBlock
    {
        int shapeSize;
        Texture2D blockTexture;
        public abstract bool[,] shape { get; set; }
        public abstract Color color { get; set; }

        protected TetrisBlock(int shapeSize)
        {
            this.shapeSize = shapeSize;
            blockTexture = TetrisGame.ContentManager.Load<Texture2D>("whiteblock");
        }

        public void RotateClockwise()
        {
            bool[,] rotatedShape = new bool[shapeSize, shapeSize];
            for (int i = 0; i < shapeSize; i++)
                for (int j = 0; j < shapeSize; j++)
                    rotatedShape[j, Math.Abs(i - shapeSize + 1)] = shape[i, j];

            shape = rotatedShape;
        }

        public void RotateCounterClockwise()
        {
            bool[,] rotatedShape = new bool[shapeSize, shapeSize];
            for (int i = 0; i < shapeSize; i++)
                for (int j = 0; j < shapeSize; j++)
                    rotatedShape[Math.Abs(j - shapeSize + 1), i] = shape[i, j];

            shape = rotatedShape;
        }

        public void Update(GameTime gameTime)
        {

        }
        
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Vector2 position)
        {
            for (int i = 0; i < shapeSize; i++)
                for (int j = 0; j < shapeSize; j++)
                    if (shape[i, j])
                        spriteBatch.Draw(blockTexture, new Vector2(position.X + j * blockTexture.Width, position.Y + i * blockTexture.Height), color);
        }
    }
}

