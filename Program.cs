using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bizcuit_Engine.Engine;

namespace Bizcuit_Engine
{
    class Program
    {
        
        static void Main(string[] args)
        {
            /**
             * engine will run as a part of the gui and demo. It acts as the motor to make everything work. The work space is where a game could be assembled but game could run seperately.
             * But workspace could run the game in there too. For the purpose of this file, it will run the engine, demo, and workspace one at a time. First engine with console commands and then either game or
             * workspace comes next.
             */

            //running engine


            //running work-space

            //running demo
            DemoGame.Billy_Yank_and_the_Big_Iron_on_His_Hip game = new DemoGame.Billy_Yank_and_the_Big_Iron_on_His_Hip("Billy Yank and the Big Iron on His Hip");
            game.Run();
        }
    }
}
