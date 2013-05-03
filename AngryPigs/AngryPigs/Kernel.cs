using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using AngryPigs.GameEntitites;

namespace AngryPigs
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Kernel : Microsoft.Xna.Framework.Game
    {

        #region FIELDS

        //Kernel is automatically created and stored as static field - enforces threadsafe singleton pattern
        private static readonly Kernel instance = new Kernel();

        //GRAPHICS
        private Texture2D backgroundTexture;
        private Texture2D pigTest;
        private Pig pigObjectTest;

        //INPUT
        // Keyboard states used to determine key presses
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        // Gamepad states used to determine button presses
        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTOR

        // Threadsafe singleton pattern - this pattern was chosen as it simplifies threadsafe singleton checking by not requiring locks,
        // but at the cost of not being fully lazy. This was considered optimal in this situation as we will always want the Kernel instantiating, 
        // and just want to ensure no others are created - pattern source: http://csharpindepth.com/Articles/General/Singleton.aspx

        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static Kernel()
        {
        }

        // private constructor - enforces threadsafe singleton pattern
        private Kernel()
        {
            graphics = new GraphicsDeviceManager(this);
            // set window to 1366x768
            graphics.PreferredBackBufferHeight = 768;
            graphics.PreferredBackBufferWidth = 1366;
            Content.RootDirectory = "Content";
        }

        // Static property to access single Kernel object - enforces threadsafe singleton pattern
        public static Kernel Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        #region INITIALISE

        protected override void Initialize()
        {
            // TEMP create game entities
            pigObjectTest = new Pig();
            // TEMP initialise game entities
            pigObjectTest.Initialise(1, "Pig1", new Vector3(600, 695,0), Content.Load<Texture2D>("Graphics/Pig1"), new Vector3(8,0,0));

            base.Initialize();
        }

        #endregion

        #region LOAD CONTENT

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            backgroundTexture = Content.Load<Texture2D>("Graphics/Background 1366x768");
            pigTest = Content.Load<Texture2D>("Graphics/Pig1");

        }

        #endregion

        #region UNLOAD CONTENT

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        #endregion

        #region UPDATE

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // Save the previous state of the keyboard and game pad so we can determinesingle key/button presses
            previousGamePadState = currentGamePadState;
            previousKeyboardState = currentKeyboardState;

            // Read the current state of the keyboard and gamepad and store it
            currentKeyboardState = Keyboard.GetState();
            currentGamePadState = GamePad.GetState(PlayerIndex.One);

            UpdatePlayer(gameTime);

            base.Update(gameTime);
        }

        #endregion

        #region DRAW

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            DrawScenery();
            spriteBatch.Draw(pigTest, new Rectangle(500, 500, 70, 64), Color.White);
            // TEMP draw game entities
            pigObjectTest.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion

        #region METHODS

        private void DrawScenery()
        {
            int screenWidth;
            int screenHeight;

            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

            Rectangle screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);
            spriteBatch.Draw(backgroundTexture, screenRectangle, Color.White);
        }


        // ++++ NEEDS MOVING TO PIG MIND +++++ //
        private void UpdatePlayer(GameTime gameTime)
        {

            // update player
            pigObjectTest.Update(gameTime);

            //// Get Thumbstick Controls
            //pigObjectTest.Position = new Vector2(currentGamePadState.ThumbSticks.Left.X * pigObjectTest.Velocity, pigObjectTest.Position.Y);
            //pigObjectTest.Position = new Vector2(pigObjectTest.Position.X, currentGamePadState.ThumbSticks.Left.Y * pigObjectTest.Velocity);

            // Use the Keyboard / Dpad
            if (currentKeyboardState.IsKeyDown(Keys.A) ||
            currentGamePadState.DPad.Left == ButtonState.Pressed)
            {
                pigObjectTest.MoveLeft();
            }
            if (currentKeyboardState.IsKeyDown(Keys.D) ||
            currentGamePadState.DPad.Right == ButtonState.Pressed)
            {
                pigObjectTest.MoveRight();
            }
            if (currentKeyboardState.IsKeyDown(Keys.W) ||
            currentGamePadState.DPad.Up == ButtonState.Pressed)
            {
                // IMPLEMENT JUMP
            }
            if (currentKeyboardState.IsKeyDown(Keys.S) ||
            currentGamePadState.DPad.Down == ButtonState.Pressed)
            {
                // IMPLEMENT SHIELD ACTIVATION?
            }

            //// Make sure that the player does not go out of bounds
            //player.Position.X = MathHelper.Clamp(player.Position.X, 0, GraphicsDevice.Viewport.Width - player.Width);
            //player.Position.Y = MathHelper.Clamp(player.Position.Y, 0, GraphicsDevice.Viewport.Height - player.Height);
        }

        #endregion
    }
}
