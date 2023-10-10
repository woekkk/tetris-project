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
        public abstract bool[,] shape { get; set; }

        protected TetrisBlock(int shapeSize)
        {
            this.shapeSize = shapeSize;
        }

        public void Rotate(bool[,] shape)
        {

        }
        
        public void Update(GameTime gameTime)
        {

        }
        
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            for (int i = 0; i < shapeSize; i++)
            {
                for (int j = 0; j < shapeSize; j++)
                {
                    if (shape[i, j])
                        spriteBatch.Draw(TetrisGame.ContentManager.Load<Texture2D>("block"), new Vector2(j * TetrisGame.ContentManager.Load<Texture2D>("block").Width, i * TetrisGame.ContentManager.Load<Texture2D>("block").Height), Color.Red);
                }
            }

            spriteBatch.End();
        }
    }
}

