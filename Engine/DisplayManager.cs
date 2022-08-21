using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcuit_Engine.Engine
{
    static class DisplayManager
    {
        public static RenderWindow window;
        public static View camera;

        public static float aspectRatio;
        

        const float VIEW_HEIGHT = 144;
        const float VIEW_WIDTH = 160;

        
        public static void CreateWindow(string gameName)
        {
            window = new RenderWindow(new VideoMode(160, 144), gameName, Styles.Resize | Styles.Close);
            camera = new View(new FloatRect(0.0f, 0.0f, VIEW_WIDTH, VIEW_HEIGHT));
            //window.SetView(CalcView(window.Size, new Vector2u(160, 144)));

            Console.WriteLine(window.Size.X);
            Console.WriteLine(window.Size.Y);
            Console.WriteLine(aspectRatio);
            aspectRatio = (float)window.Size.X / window.Size.Y;
            Console.WriteLine(aspectRatio);
            window.Closed += HandleClose;//If window is closed
            window.Resized += HandleResize;//If window is resized
            window.KeyPressed += HandleKeyPressed;//Adding close game button
            
        }

        private static void HandleClose(object sender, EventArgs e)
        {
            window.Close();
        }

        private static void HandleResize(object sender, SizeEventArgs e)
        {
            Console.WriteLine(e.Width);
            Console.WriteLine(aspectRatio);
            camera = CalcView(new Vector2u(e.Width, e.Height), new Vector2u(160, 144));
            window.SetView(camera);
            Console.WriteLine("New window width: " + window.Size.X + " New window height: " + window.Size.Y);
            Console.WriteLine("New window width: " + e.Width + " New window height: " + e.Height);
            Console.WriteLine(window.GetView());
            Console.WriteLine(window.GetView().Center) ;
        }

        private static void HandleKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.F4)
            {
                window.Close();
            }
            
        }

        private static View CalcView(Vector2u windowSize, Vector2u designedSize)
        {
            
                FloatRect viewPort = new FloatRect(0, 0, 1, 1);

                float screenwidth = (float)windowSize.X / designedSize.X;
                float screenheight = (float)windowSize.Y / designedSize.Y;

                if (screenwidth > screenheight)
                {
                    viewPort.Width = screenheight / screenwidth;
                    viewPort.Left = (1 - viewPort.Width) / 2;
                }
                else if (screenwidth < screenheight)
                {
                    viewPort.Height = screenwidth / screenheight;
                    viewPort.Top = (1 - viewPort.Height) / 2;
                }

                View view = new View(new FloatRect( 0, 0, designedSize.X, designedSize.Y ));
            view.Viewport = viewPort;

                return view;
            
        }









        //public static Clock clock;
        //public static GOList gameObjectList;
        //public string title;
        //public static bool debug;
        //public static bool pause;
        //static bool test;
        //static RectangleShape test2 = new RectangleShape(new Vector2f(50.0f, 50.0f));
        /*public DisplayManager(string gameName, GOList gamebjObjectList, bool debug)
        {
            //title = gameName;
            CreateWindow(gameName);
            LoadObjects(gameObjectList);
            if(debug == false)
            {
                RunWindowLoop();
            }
            else
            {
                RunDebugWindowLoop();
            }
            

        }*/
        //clock = new Clock();
        //test = true;
        //test = true;



        /*if (e.Code == Keyboard.Key.F11 && debug == true)
            {
                pause = !pause;
            }*/

        /*public static void LoadObjects(GOList gameObjectList)
        {
            //this.gameObjectList = gameObjectList;
            window.Closed += HandleClose;//If window is closed
            window.Resized += HandleResize;//If window is resized
            window.KeyPressed += HandleKeyPressed;//Adding close game button

            test2.FillColor=Color.Green;
            test2.Position = new Vector2f(0,0);
            Console.WriteLine("creating");
            window.Draw(test2);
            Console.WriteLine("I'm here");
        */

        /*public static void RunWindowLoop()
        {
         
            while (window.IsOpen)//where the magic happens BB
            {
                GameTime.DeltaTime = clock.ElapsedTime.AsSeconds() - GameTime.TotalElapsedSeconds;
                GameTime.TotalElapsedSeconds = clock.ElapsedTime.AsSeconds();
                //window.DispatchEvents();
                
                /*.Clear(Color.Blue);
                window.Draw(test2);
                window.SetView(camera);
                
                if (test)
                {
                    Console.WriteLine("test2");
                    
                    Console.WriteLine(window.GetView());
                    test = false;
                }

                window.Display();
            }
        }*/

        /*public static void RunDebugWindowLoop()
        {
            pause = false;
            while (window.IsOpen)//where the magic happens BB
            {
                window.DispatchEvents();
                if(pause == false)
                {
                    window.Clear(Color.Blue);
                    window.Draw(test2);
                }
                

                
                window.SetView(camera);

                if (test)
                {
                    Console.WriteLine("test2");

                    Console.WriteLine(window.GetView());
                    test = false;
                }

                window.Display();
            }
        }*/
    }
}


/*using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcuit_Engine.Engine
{
    static class DisplayManager
    {
        public static RenderWindow window;
        public static View camera;

        public static float aspectRatio;
        

        const float VIEW_HEIGHT = 144;
        const float VIEW_WIDTH = 160;

        
        public static void CreateWindow(string gameName)
        {
            window = new RenderWindow(new VideoMode(160, 144), gameName, Styles.Resize | Styles.Close);
            camera = new View(new FloatRect(0.0f, 0.0f, VIEW_WIDTH, VIEW_HEIGHT));
            //window.SetView(CalcView(window.Size, new Vector2u(160, 144)));

            Console.WriteLine(window.Size.X);
            Console.WriteLine(window.Size.Y);
            Console.WriteLine(aspectRatio);
            aspectRatio = (float)window.Size.X / window.Size.Y;
            Console.WriteLine(aspectRatio);
            window.Closed += HandleClose;//If window is closed
            window.Resized += HandleResize;//If window is resized
            window.KeyPressed += HandleKeyPressed;//Adding close game button
            
        }

        private static void HandleClose(object sender, EventArgs e)
        {
            window.Close();
        }

        private static void HandleResize(object sender, SizeEventArgs e)
        {
            Console.WriteLine(e.Width);
            Console.WriteLine(aspectRatio);
            //Vector2f size = new Vector2f(window.Size.X, window.Size.Y);
            //camera = new View(new FloatRect(0, 0, e.Width * aspectRatio, e.Height * aspectRatio));
            //camera.Size = new Vector2f(VIEW_WIDTH * aspectRatio, VIEW_HEIGHT * aspectRatio);
            camera = CalcView(new Vector2u(e.Width, e.Height), new Vector2u(160, 144));
            window.SetView(camera);
            
            //window.SetView(CalcView(new Vector2u(e.Width, e.Height), new Vector2u(160, 144)));
            Console.WriteLine("New window width: " + window.Size.X + " New window height: " + window.Size.Y);
            Console.WriteLine("New window width: " + e.Width + " New window height: " + e.Height);
            Console.WriteLine(window.GetView());
            Console.WriteLine(window.GetView().Center) ;
        }

        private static void HandleKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.F4)
            {
                window.Close();
            }
            
        }

        private static View CalcView(Vector2u windowSize, Vector2u designedSize)
        {
            
                FloatRect viewPort = new FloatRect(0, 0, 1, 1);

                float screenwidth = (float)windowSize.X / designedSize.X;
                float screenheight = (float)windowSize.Y / designedSize.Y;

                if (screenwidth > screenheight)
                {
                    viewPort.Width = screenheight / screenwidth;
                    viewPort.Left = (1 - viewPort.Width) / 2;
                }
                else if (screenwidth < screenheight)
                {
                    viewPort.Height = screenwidth / screenheight;
                    viewPort.Top = (1 - viewPort.Height) / 2;
                }

                View view = new View(new FloatRect( 0, 0, designedSize.X, designedSize.Y ));
            view.Viewport = viewPort;

                return view;
            
        }









        //public static Clock clock;
        //public static GOList gameObjectList;
        //public string title;
        //public static bool debug;
        //public static bool pause;
        //static bool test;
        //static RectangleShape test2 = new RectangleShape(new Vector2f(50.0f, 50.0f));
        /*public DisplayManager(string gameName, GOList gamebjObjectList, bool debug)
        {
            //title = gameName;
            CreateWindow(gameName);
            LoadObjects(gameObjectList);
            if(debug == false)
            {
                RunWindowLoop();
            }
            else
            {
                RunDebugWindowLoop();
            }
            

        }*/
        //clock = new Clock();
        //test = true;
        //test = true;



        /*if (e.Code == Keyboard.Key.F11 && debug == true)
            {
                pause = !pause;
            }*/

        /*public static void LoadObjects(GOList gameObjectList)
        {
            //this.gameObjectList = gameObjectList;
            window.Closed += HandleClose;//If window is closed
            window.Resized += HandleResize;//If window is resized
            window.KeyPressed += HandleKeyPressed;//Adding close game button

            test2.FillColor=Color.Green;
            test2.Position = new Vector2f(0,0);
            Console.WriteLine("creating");
            window.Draw(test2);
            Console.WriteLine("I'm here");
        */

        /*public static void RunWindowLoop()
        {
         
            while (window.IsOpen)//where the magic happens BB
            {
                GameTime.DeltaTime = clock.ElapsedTime.AsSeconds() - GameTime.TotalElapsedSeconds;
                GameTime.TotalElapsedSeconds = clock.ElapsedTime.AsSeconds();
                //window.DispatchEvents();
                
                /*.Clear(Color.Blue);
                window.Draw(test2);
                window.SetView(camera);
                
                if (test)
                {
                    Console.WriteLine("test2");
                    
                    Console.WriteLine(window.GetView());
                    test = false;
                }

                window.Display();
            }
        }*/

        /*public static void RunDebugWindowLoop()
        {
            pause = false;
            while (window.IsOpen)//where the magic happens BB
            {
                window.DispatchEvents();
                if(pause == false)
                {
                    window.Clear(Color.Blue);
                    window.Draw(test2);
                }
                

                
                window.SetView(camera);

                if (test)
                {
                    Console.WriteLine("test2");

                    Console.WriteLine(window.GetView());
                    test = false;
                }

                window.Display();
            }
        }
    }
}*/
