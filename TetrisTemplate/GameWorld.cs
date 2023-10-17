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


    /// <summary>
    /// A class for generating a random block with a random rotation. If the parameter is false, the currentBlock (most likely) won't be the same as the previous nextBlock.
    /// </summary>
    /// <param name="firstBlock"></param>
    /// <returns></returns>
    public TetrisBlock RandomBlock(bool firstBlock)
    {

        TetrisBlock temporaryBlock;
        
        // This if statement sets the current block as the (previous) next block UNLESS currentBlock and nextBlock are assigned for the first time
        if (!firstBlock)
            currentBlock = nextBlock;
        
        // This switch statement determines which of the 7 block-types the next block will be
        switch (Random.Next(0, 7))
        {
            case 0:
                temporaryBlock = new BlockI();
                break;
            case 1:
                temporaryBlock = new BlockL();
                break;
            case 2:
                temporaryBlock = new BlockJ();
                break;
            case 3:
                temporaryBlock = new BlockS();
                break;
            case 4:
                temporaryBlock = new BlockZ();
                break;
            case 5:
                temporaryBlock = new BlockT();
                break;
            default:
                temporaryBlock = new BlockO();
                break;
        }

        // This switch statement makes the new block spawn in a random rotation
        switch (Random.Next(0, 3))
        {
            case 0:
                temporaryBlock.RotateClockwise();
                return temporaryBlock;
            case 1:
                temporaryBlock.RotateCounterClockwise();
                return temporaryBlock;
            case 2:
                temporaryBlock.RotateClockwise();
                temporaryBlock.RotateClockwise();
                return temporaryBlock;
            default:
                return temporaryBlock;
        }
    }

    public void Reset()
    {
    }

}
