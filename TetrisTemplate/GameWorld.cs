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

    // The current and next Tetrisblock and their positions
    public TetrisBlock currentBlock;
    public TetrisBlock nextBlock;
    Vector2 currentBlockPosition;
    Vector2 nextBlockPosition;

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

        currentBlock = RandomBlock(true);
        nextBlock = RandomBlock(true);

        currentBlockPosition = new Vector2(50, 0);
        nextBlockPosition = new Vector2(500, 80);
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
            nextBlock = RandomBlock(false);
    }

    public void Update(GameTime gameTime)
    {
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        grid.Draw(gameTime, spriteBatch);
        currentBlock.Draw(gameTime, spriteBatch, currentBlockPosition);
        nextBlock.Draw(gameTime, spriteBatch, nextBlockPosition);
        spriteBatch.DrawString(font, "Next Block:", new Vector2(500, 50), Microsoft.Xna.Framework.Color.Black);
        spriteBatch.End();
    }

    public TetrisBlock RandomBlock(bool firstBlock)
    {
        if (!firstBlock)
            currentBlock = nextBlock;
        
        switch (Random.Next(0, 7))
        {
            case 0:
                return new BlockI();
            case 1:
                return new BlockL();
            case 2:
                return new BlockJ();
            case 3:
                return new BlockS();
            case 4:
                return new BlockZ();
            case 5:
                return new BlockT();
            case 6:
                return new BlockO();
            default:
                return null;
        }
    }

    public void Reset()
    {
    }

}
