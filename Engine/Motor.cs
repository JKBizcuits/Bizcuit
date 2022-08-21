using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM = Bizcuit_Engine.Engine.DisplayManager;
using GOL = Bizcuit_Engine.Engine.GOList;

namespace Bizcuit_Engine.Engine
{
    abstract class Motor
    {
        protected Clock clock;
        protected string gameTitle;
        

        public Motor(string gameTitle)
        {
            this.gameTitle = gameTitle;
            clock = new Clock();
            GOL.gameObjectList = new Dictionary<string, GameObject>();
        }

        public void Run()
        {
            Initialize();

            DM.CreateWindow(gameTitle);


            LoadContent();

            while (DM.window.IsOpen)
            {
                GameTime.DeltaTime = clock.ElapsedTime.AsSeconds() - GameTime.TotalElapsedSeconds;
                GameTime.TotalElapsedSeconds = clock.ElapsedTime.AsSeconds();

                Update();
                DM.window.DispatchEvents();
                Render();
            }
        }

        protected abstract void Initialize(); //load settings, setting initial window size
        protected abstract void LoadContent();//load initial content
        protected abstract void Update();
        protected abstract void Render();

    }
}


//DisplayManager mainWindow;
//GOList gameObjectList;
/*public Motor()
{
    gameObjectList = new GOList();
}*/

/*public void Run(string gameName, bool debug)
{
    //mainWindow = new MainWindow(gameName, debug);
}*/
