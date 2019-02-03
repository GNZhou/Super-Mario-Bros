using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{

    class MovingNotAnimatedCommand : ICommand
    {
        public Game1 MyGame { get; set; }

        public MovingNotAnimatedCommand(Game1 game)
        {
            MyGame = game;
        }

        public void Execute()
        {
            MyGame.BuildSprite(Game1.MarioMovement.MovingNotAnimated);
        }
    }

}