using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public interface ICommand
    {
        Game1 MyGame { get; set; }
        void Execute();
    }
}
