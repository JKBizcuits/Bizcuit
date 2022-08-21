using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bizcuit_Engine.Engine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using DM = Bizcuit_Engine.Engine.DisplayManager;
using GOL = Bizcuit_Engine.Engine.GOList;

namespace Bizcuit_Engine.DemoGame
{
    class Billy_Yank_and_the_Big_Iron_on_His_Hip : Motor
    {

        Player player;
        Vector2f direction;
        Background background;
        Tile t011, t021, t031, t041, t051;
        public Billy_Yank_and_the_Big_Iron_on_His_Hip(string gameTitle) : base(gameTitle)
        {

        }

        protected override void Initialize()
        {

        }

        protected override void LoadContent()
        {
            direction = new Vector2f();
            background = new Background("Moon");
            //background = new Sprite(new Texture(@"..\..\Textures\MoonBackground.png"));
            
            player = new Player("Timmy");
            background.body.Origin = player.body.Origin;
            t011 = new Tile(0, 0, true);
            t011.body.Position = new Vector2f(-16, player.body.Position.Y + 32);
            t011.collisionBox.Position = new Vector2f(t011.body.Position.X, t011.body.Position.Y + 9);
            t021 = new Tile(1, 0, true);
            t021.body.Position = new Vector2f(-8, player.body.Position.Y + 32);
            t021.collisionBox.Position = new Vector2f(t021.body.Position.X, t021.body.Position.Y + 9);
            t031 = new Tile(2, 0, true);
            t031.body.Position = new Vector2f(0, player.body.Position.Y + 32);
            t031.collisionBox.Position = new Vector2f(t031.body.Position.X, t031.body.Position.Y + 9);
            t041 = new Tile(3, 0, true);
            t041.body.Position = new Vector2f(8, player.body.Position.Y + 32);
            t041.collisionBox.Position = new Vector2f(t041.body.Position.X, t041.body.Position.Y + 9);
            t051 = new Tile(4, 0, true);
            t051.body.Position = new Vector2f(16, player.body.Position.Y + 32);
            t051.collisionBox.Position = new Vector2f(t051.body.Position.X, t051.body.Position.Y + 9);
 
        }

        protected override void Update()
        {
            player.Update(GameTime.DeltaTime);
            Console.WriteLine(direction + "4");
            if (t011.GetCollider().CheckCollision(player.GetCollider(), ref direction, 1))
            {
                Console.WriteLine(direction + "5");
                player.OnCollision(direction);
            }
            if (t021.GetCollider().CheckCollision(player.GetCollider(), ref direction, 1))
            {
                player.OnCollision(direction);
            }
            if (t031.GetCollider().CheckCollision(player.GetCollider(), ref direction, 1))
            {
                player.OnCollision(direction);
            }
            if (t041.GetCollider().CheckCollision(player.GetCollider(), ref direction, 1))
            {
                player.OnCollision(direction);
            }
            if (t051.GetCollider().CheckCollision(player.GetCollider(), ref direction, 1))
            {
                player.OnCollision(direction);
            }

            background.body.Position = new Vector2f(player.body.Position.X, player.body.Position.Y - 32);
            DM.camera.Center = new Vector2f(player.body.Position.X, player.body.Position.Y - 32);

            
        }

        protected override void Render()
        {

            DM.window.Clear(Color.Blue);
            DM.window.SetView(DM.camera);
            background.Draw(DM.window);
            player.Draw(DM.window);
            t011.Draw(DM.window);
            t021.Draw(DM.window);
            t031.Draw(DM.window);
            t041.Draw(DM.window);
            t051.Draw(DM.window);
            DM.window.Draw(t011.collisionBox);
            DM.window.Draw(t021.collisionBox);
            DM.window.Draw(t031.collisionBox);
            DM.window.Draw(t041.collisionBox);
            DM.window.Draw(t051.collisionBox);
            DM.window.Display();
        }

        
    }
}



/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bizcuit_Engine.Engine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using DM = Bizcuit_Engine.Engine.DisplayManager;
using GOL = Bizcuit_Engine.Engine.GOList;

namespace Bizcuit_Engine.DemoGame
{
    class Billy_Yank_and_the_Big_Iron_on_His_Hip : Motor
    {
        int zerozero = 0;
        int zeroone = 1;
        int zerotwo = 2;
        int zerothree = 3;
        int zerofour = 4;

        int onezero = 0;
        int oneone = 1;
        int onetwo = 2;
        int onethree = 3;

        int twozero = 0;
        int twoone = 1;

        int threezero = 0;
        int threeone = 1;
        int threetwo = 2;
        int threethree = 3;
        int threefour = 4;
        Player player;
        Vector2f direction;
        Sprite background;
        //Tile t011, t021, t031, t041, t051, t012, t022, t032, t042, t052, t013, t023, t033, t043, t053, t014, t024, t034, t044, t054, t015, t025, t035, t045, t055, t016, t026, t036, t046, t056, t017, t027, t037, t047, t057,
        // t061, t071, t081, t091, t062, t072, t082, t092,
        //t101, t111, t102, t112, t103, t113,
        //t121, t131, t141, t151, t161, t122, t132, t142, t152, t162, t123, t133, t143, t153, t163, t124, t134, t144, t154, t164;

        // Tile[] list;
        Tile t011, t021, t031, t041, t051;
        public Billy_Yank_and_the_Big_Iron_on_His_Hip(string gameTitle) : base(gameTitle)
        {

        }

        protected override void Initialize()
        {

        }

        protected override void LoadContent()
        {
            direction = new Vector2f();
            background = new Sprite(new Texture(@"..\..\Textures\MoonBackground.png"));
            background.Origin = new Vector2f(background.Texture.Size.X / 2, background.Texture.Size.Y / 2);
            player = new Player("Timmy");
            t011 = new Tile(0, 0, true);
            t011.body.Position = new Vector2f(-16, player.body.Position.Y + 32);
            t011.collisionBox.Position = new Vector2f(t011.body.Position.X, t011.body.Position.Y + 9);
            t021 = new Tile(1, 0, true);
            t021.body.Position = new Vector2f(-8, player.body.Position.Y + 32);
            t021.collisionBox.Position = new Vector2f(t021.body.Position.X, t021.body.Position.Y + 9);
            t031 = new Tile(2, 0, true);
            t031.body.Position = new Vector2f(0, player.body.Position.Y + 32);
            t031.collisionBox.Position = new Vector2f(t031.body.Position.X, t031.body.Position.Y + 9);
            t041 = new Tile(3, 0, true);
            t041.body.Position = new Vector2f(8, player.body.Position.Y + 32);
            t041.collisionBox.Position = new Vector2f(t041.body.Position.X, t041.body.Position.Y + 9);
            t051 = new Tile(4, 0, true);
            t051.body.Position = new Vector2f(16, player.body.Position.Y + 32);
            t051.collisionBox.Position = new Vector2f(t051.body.Position.X, t051.body.Position.Y + 9);
            /*
            t011 = new Tile(0,0, true);
            t021 = new Tile(1, 0, true);
            t031 = new Tile(2, 0, true);
            t041 = new Tile(3, 0, true);
            t051 = new Tile(4, 0, true);
            t012 = new Tile(0, 0, true);
            t022 = new Tile(1, 0, true);
            t032 = new Tile(2, 0, true);
            t042 = new Tile(3, 0, true);
            t052 = new Tile(4, 0, true);
            t013 = new Tile(0, 0, true);
            t023 = new Tile(1, 0, true);
            t033 = new Tile(2, 0, true);
            t043 = new Tile(3, 0, true);
            t053 = new Tile(4, 0, true);
            t014 = new Tile(0, 0, true);
            t024 = new Tile(1, 0, true);
            t034 = new Tile(2, 0, true);
            t044 = new Tile(3, 0, true);
            t054 = new Tile(4, 0, true);
            t015 = new Tile(0, 0, true);
            t025 = new Tile(1, 0, true);
            t035 = new Tile(2, 0, true);
            t045 = new Tile(3, 0, true);
            t055 = new Tile(4, 0, true);
            t016 = new Tile(0, 0, true);
            t026 = new Tile(1, 0, true);
            t036 = new Tile(2, 0, true);
            t046 = new Tile(3, 0, true);
            t056 = new Tile(4, 0, true);
            t017 = new Tile(0, 0, true);
            t027 = new Tile(1, 0, true);
            t037 = new Tile(2, 0, true);
            t047 = new Tile(3, 0, true);
            t057 = new Tile(4, 0, true);


            t061 = new Tile(0, 1, true);
            t071 = new Tile(1, 1, true);
            t081 = new Tile(2, 1, true);
            t091 = new Tile(3, 1, true);
            t062 = new Tile(0, 1, false);
            t072 = new Tile(1, 1, false);
            t082 = new Tile(2, 1, false);
            t092 = new Tile(3, 1, false);

            t101 = new Tile(0, 2, true);
            t111 = new Tile(1, 2, true);
            t102 = new Tile(0, 2, false);
            t112 = new Tile(1, 2, false);
            t103 = new Tile(0, 2, true);
            t113 = new Tile(1, 2, true);

            t121 = new Tile(0, 3, true);
            t131 = new Tile(1, 3, true);
            t141 = new Tile(2, 3, true);
            t151 = new Tile(3, 3, true);
            t161 = new Tile(4, 3, true);
            t122 = new Tile(0, 3, true);
            t132 = new Tile(1, 3, true);
            t142 = new Tile(2, 3, true);
            t152 = new Tile(3, 3, true);
            t162 = new Tile(4, 3, true);
            t123 = new Tile(0, 3, true);
            t133 = new Tile(1, 3, true);
            t143 = new Tile(2, 3, true);
            t153 = new Tile(3, 3, true);
            t163 = new Tile(4, 3, true);
            t124 = new Tile(0, 3, true);
            t134 = new Tile(1, 3, true);
            t144 = new Tile(2, 3, true);
            t154 = new Tile(3, 3, true);
            t164 = new Tile(4, 3, true);
        
            list = new Tile[] {
                t011, t021, t031, t041, t051, t012, t022, t032, t042, t052, t013, t023, t033, t043, t053, t014, t024, t034, t044, t054, t015, t025, t035, t045, t055, t016, t026, t036, t046, t056, t017, t027, t037, t047, t057,
            t061, t071, t081, t091, t062, t072, t082, t092,
            t101, t111, t102, t112, t103, t113,
            t121, t131, t141, t151, t161, t122, t132, t142, t152, t162, t123, t133, t143, t153, t163, t124, t134, t144, t154, t164
            };

            foreach(Tile thing in list)
            {
                

                thing.body.Position = new Vector2f(player.body.Position.X, thing.body.Position.Y + 32);
                if(thing.selectedTexture.X == 0)
                {
                    if(thing.selectedTexture.Y == 0)
                    {
                        Console.WriteLine("works");
                        Console.WriteLine(thing.body.Position);
                        thing.body.Position = new Vector2f(8 * zerozero, thing.body.Position.Y);
                        Console.WriteLine(thing.body.Position);
                        zerozero+=5;

                    } 
                    else if (thing.selectedTexture.Y == 1)
                    {
                        Console.WriteLine("works1");
                        thing.body.Position = new Vector2f(8 * zeroone, thing.body.Position.Y);
                        zeroone+=5;

                    }
                    else if (thing.selectedTexture.Y == 2)
                    {
                        Console.WriteLine("works2");
                        thing.body.Position = new Vector2f(8 * zerotwo, thing.body.Position.Y);
                        zerotwo+=5;

                    }
                    else if (thing.selectedTexture.Y == 3)
                    {
                        Console.WriteLine("works3");
                        thing.body.Position = new Vector2f(8 * zerothree, thing.body.Position.Y);
                        zerothree+=5;

                    }
                    else if (thing.selectedTexture.Y == 4)
                    {
                        Console.WriteLine("works4");
                        thing.body.Position = new Vector2f(8 * zerofour, thing.body.Position.Y);
                        zerofour+=5;

                    }


                }
                else if (thing.selectedTexture.X == 1)
                {
                    if (thing.selectedTexture.Y == 0)
                    {
                        thing.body.Position = new Vector2f(12 * onezero, thing.body.Position.Y);
                        onezero+=4;

                    }
                    else if (thing.selectedTexture.Y == 1)
                    {
                        thing.body.Position = new Vector2f(12 * oneone, thing.body.Position.Y);
                        oneone+=4;

                    }
                    else if (thing.selectedTexture.Y == 2)
                    {
                        thing.body.Position = new Vector2f(12 * onetwo, thing.body.Position.Y);
                        onetwo+=4;

                    }
                    else if (thing.selectedTexture.Y == 3)
                    {
                        thing.body.Position = new Vector2f(12 * onethree, thing.body.Position.Y);
                        onethree+=4;

                    }


                }
                else if (thing.selectedTexture.X == 2)
                {
                    if (thing.selectedTexture.Y == 0)
                    {
                        thing.body.Position = new Vector2f(20 * twozero, thing.body.Position.Y);
                        twozero+=2;

                    }
                    else if (thing.selectedTexture.Y == 1)
                    {
                        thing.body.Position = new Vector2f(20 * twoone, thing.body.Position.Y);
                        twoone+=2;

                    }

                }
                else if (thing.selectedTexture.X == 3)
                {
                    if (thing.selectedTexture.Y == 0)
                    {
                        thing.body.Position = new Vector2f(11 * zerozero, thing.body.Position.Y);
                        threezero+=5;

                    }
                    else if (thing.selectedTexture.Y == 1)
                    {
                        thing.body.Position = new Vector2f(11 * zeroone, thing.body.Position.Y);
                        threeone+=5;

                    }
                    else if (thing.selectedTexture.Y == 2)
                    {
                        thing.body.Position = new Vector2f(11 * zerotwo, thing.body.Position.Y);
                        threetwo+=5;

                    }
                    else if (thing.selectedTexture.Y == 3)
                    {
                        thing.body.Position = new Vector2f(11 * zerothree, thing.body.Position.Y);
                        threethree+=5;

                    }
                    else if (thing.selectedTexture.Y == 4)
                    {
                        thing.body.Position = new Vector2f(11 * zerofour, thing.body.Position.Y);
                        threefour+=5;

                    }


                }
                Console.WriteLine(thing.body.Position);
                Console.WriteLine(thing.selectedTexture);
            }
        }

        protected override void Update()
{
    player.Update(GameTime.DeltaTime);
    Console.WriteLine(direction + "4");
    if (t011.GetCollider().CheckCollision(player.GetCollider(), ref direction, 1))
    {
        Console.WriteLine(direction + "5");
        player.OnCollision(direction);
    }
    if (t021.GetCollider().CheckCollision(player.GetCollider(), ref direction, 1))
    {
        player.OnCollision(direction);
    }
    if (t031.GetCollider().CheckCollision(player.GetCollider(), ref direction, 1))
    {
        player.OnCollision(direction);
    }
    if (t041.GetCollider().CheckCollision(player.GetCollider(), ref direction, 1))
    {
        player.OnCollision(direction);
    }
    if (t051.GetCollider().CheckCollision(player.GetCollider(), ref direction, 1))
    {
        player.OnCollision(direction);
    }

    background.Position = new Vector2f(player.body.Position.X, player.body.Position.Y - 32);

    //DM.camera = new View(new FloatRect(0, 0, 160, 144));
    //Console.WriteLine(DM.camera.Size);
    DM.camera.Center = new Vector2f(player.body.Position.X, player.body.Position.Y - 32);


}

protected override void Render()
{

    DM.window.Clear(Color.Blue);
    //window.Draw(test2);


    DM.window.SetView(DM.camera);
    //DM.window.Draw(background);
    player.Draw(DM.window);

    //DM.window.Draw(player.collisionBox);
    //Console.WriteLine(player.collisionBox.Position);

    /*foreach (Tile thing in list)
    {
        if(thing.selectedTexture.Y == 0)
        {
            thing.Draw(DM.window);
        }



    }
    t011.Draw(DM.window);
    t021.Draw(DM.window);
    t031.Draw(DM.window);
    t041.Draw(DM.window);
    t051.Draw(DM.window);
    DM.window.Draw(t011.collisionBox);
    DM.window.Draw(t021.collisionBox);
    DM.window.Draw(t031.collisionBox);
    DM.window.Draw(t041.collisionBox);
    DM.window.Draw(t051.collisionBox);
    //Console.WriteLine(t031.body.Position);
    DM.window.Display();
}

        
    }
}
*/