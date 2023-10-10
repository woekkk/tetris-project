using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;
using TetrisTemplate;

/// <summary>
/// A class for representing the game world.
/// This contains the grid, the falling block, and everything else that the player can see/do.
/// </summary>
class GameWorld
{
    /// <summary>
    /// An enum for the different game states that the game can have.
    /// </summary>
    enum GameState
    {
        Playing,
        GameOver
    }

    /// <summary>
    /// The random-number generator of the game.
    /// </summary>
    public static Random Random { get { return random; } }
    static Random random;

    /// <summary>
    /// The main font of the game.
    /// </summary>
    SpriteFont font;

    /// <summary>
    /// The current game state.
    /// </summary>
    GameState gameState;

    // The current block.
    TetrisBlock currentBlock;

    /// <summary>
    /// The main grid of the game.
    /// </summary>
    TetrisGrid grid;


    public GameWorld()
    {
        random = new Random();
        gameState = GameState.Playing;

        font = TetrisGame.ContentManager.Load<SpriteFont>("SpelFont");

        grid = new TetrisGrid();
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        // Rotation
        if (inputHelper.KeyPressed(Microsoft.Xna.Framework.Input.Keys.D))
            currentBlock.RotateClockwise();
        if (inputHelper.KeyPressed(Microsoft.Xna.Framework.Input.Keys.A))
            currentBlock.RotateCounterClockwise();

        // Temporary: spawn new block
        if (inputHelper.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Space))
            NewBlock();
    }

    public void Update(GameTime gameTime)
    {
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        currentBlock.Draw(gameTime, spriteBatch);
        spriteBatch.End();
    }

    public void NewBlock()
    {
        switch (Random.Next(0, 7))
        {
            case 0:
                currentBlock = new BlockI();
                break;
            case 1:
                currentBlock = new BlockL();
                break;
            case 2:
                currentBlock = new BlockJ();
                break;
            case 3:
                currentBlock = new BlockS();
                break;
            case 4:
                currentBlock = new BlockZ();
                break;
            case 5:
                currentBlock = new BlockT();
                break;
            case 6:
                currentBlock = new BlockO();
                break;
        }
    }

    public void Reset()
    {
    }

}
