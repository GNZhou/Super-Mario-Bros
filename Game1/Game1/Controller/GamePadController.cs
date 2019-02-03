using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class GamePadController : IController
    {

        public Game1 Game { get; set; }

        private Dictionary<Buttons, ICommand> controllerMappings;

        public GamePadController(Game1 game)
        {
            this.Game = game;
            controllerMappings = new Dictionary<Buttons, ICommand>();
        }

        public void RegisterCommand(Buttons button, ICommand command)
        {
            controllerMappings.Add(button, command);
        }

        public void Update()
        {
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            List<Buttons> keyList = new List<Buttons>(controllerMappings.Keys);
            foreach (Buttons button in keyList )
            {
                if(gamePadState.IsButtonDown(button))
                {
                    controllerMappings[button].Execute();
                }
            }
            
        }

    }
}
