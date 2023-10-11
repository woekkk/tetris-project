using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// A class for representing the Tetris playing grid.
/// </summary>
class TetrisGrid
{
    /// The sprite of a single empty cell in the grid.
    Texture2D emptyCell;

    /// The position at which this TetrisGrid should be drawn.
    Vector2 position;

    /// The number of grid elements in the x-direction.
    public int Width { get { return 10; } }
   
    /// The number of grid elements in the y-direction.
    public int Height { get { return 20; } }

    enum Blocks
    {
        Nothing,
        Red,
        Yellow,
        Green,
        Indigo,
        Violet,
        Orange,
        Cyan
    }

    /// <summary>
    /// Creates a new TetrisGrid.
    /// </summary>
    /// <param name="b"></param>
    public TetrisGrid()
    {
        emptyCell = TetrisGame.ContentManager.Load<Texture2D>("blockBlack");
        position = Vector2.Zero;
        Clear();
    }
    /// <summary>
    /// Draws the grid on the screen.
    /// </summary>
    /// <param name="gameTime">An object with information about the time that has passed in the game.</param>
    /// <param name="spriteBatch">The SpriteBatch used for drawing sprites and text.</param>
    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {        
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                position.X = emptyCell.Width * i;
                position.Y = emptyCell.Height * j;
                spriteBatch.Draw(emptyCell, position, Color.White);


            }
        }
        Blocks[,] grid = new Blocks[20, 10];

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = Blocks.Nothing;
            }
        }
    }

/// <summary>
/// Clears the grid.
/// </summary>
public void Clear()
    {
    }
}

