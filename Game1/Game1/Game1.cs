using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public enum MarioMovement { AnimatedAndMoving, AnimatedNotMoving, MovingNotAnimated, NotMovingNotAnimated };

        public const int MarioSpriteWidth = 85; 
        public const int MarioSpriteHeight = 108;
        public const int InitialPosX = 375;
        public const int InitialPosY = 200;
        public const int OriginPosX = 0;
        public const int OriginPosY = 0;

        public const int FrameRow = 1;
        public const int FrameColumn = 4;
        public ISprite MarioSprite { get; set; }

        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private int maxHeight;
        private int maxWidth;
        private readonly int minWidth = 0;
        private readonly int minHeight = 0;
        private List<IController> controllerList;
        private Vector2 startPosition;
        private Texture2D marioMoving;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            controllerList = new List<IController>();

            KeyboardController keyboard = new KeyboardController(this);
            GamePadController gamepad = new GamePadController(this);

            keyboard.RegisterCommand(Keys.Q,new QuitCommand(this));
            keyboard.RegisterCommand(Keys.W, new StaticCommand(this));
            keyboard.RegisterCommand(Keys.E, new AnimatedNotMovingCommand(this));
            keyboard.RegisterCommand(Keys.R, new MovingNotAnimatedCommand(this));
            keyboard.RegisterCommand(Keys.T, new AnimatedAndMovingCommand(this));

            gamepad.RegisterCommand(Buttons.Start, new QuitCommand(this));
            gamepad.RegisterCommand(Buttons.A, new StaticCommand(this));
            gamepad.RegisterCommand(Buttons.B, new AnimatedAndMovingCommand(this));
            gamepad.RegisterCommand(Buttons.X, new MovingNotAnimatedCommand(this));
            gamepad.RegisterCommand(Buttons.Y, new AnimatedAndMovingCommand(this));


            this.controllerList.Add(keyboard);
            this.controllerList.Add(gamepad);

            startPosition = new Vector2(InitialPosX, InitialPosY);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            marioMoving = Content.Load<Texture2D>("MarioWalkingRight");
            maxHeight = GraphicsDevice.Viewport.Height;
            maxWidth = GraphicsDevice.Viewport.Width;
            MarioSprite = new StaticSprite(marioMoving, new Rectangle(OriginPosX, OriginPosX, marioMoving.Width/FrameColumn, marioMoving.Height/FrameRow),startPosition);

        }

        public void BuildSprite(MarioMovement marioState )
        {

            if(marioState==MarioMovement.NotMovingNotAnimated)
            {
                MarioSprite = new StaticSprite(marioMoving, new Rectangle(OriginPosX, OriginPosY, marioMoving.Width / FrameColumn, marioMoving.Height / FrameRow), startPosition);
            }
            else if (marioState==MarioMovement.AnimatedAndMoving)
            {
                MarioSprite = new AnimatedAndMovingSprite(marioMoving, FrameRow, FrameColumn, startPosition, maxWidth, minWidth);
            }
            else if (marioState==MarioMovement.MovingNotAnimated)
            {
                MarioSprite = new MovingNotAnimatedSprite(marioMoving, new Rectangle(OriginPosX, OriginPosY, marioMoving.Width / FrameColumn, marioMoving.Height / FrameRow), startPosition, maxHeight,minHeight);
            }
            else if (marioState==MarioMovement.AnimatedNotMoving)
            {
                MarioSprite = new AnimatedNotMovingSprite(marioMoving, FrameRow, FrameColumn, startPosition);
            }


        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            MarioSprite.Update();

            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            MarioSprite.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            MarioSprite.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
