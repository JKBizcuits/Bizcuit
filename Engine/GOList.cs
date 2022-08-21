using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcuit_Engine.Engine
{
    static class GOList
    {
        public static Dictionary<string, GameObject> gameObjectList { get; set; }
        private static int count;

        /*public static void Add(string gameObjectName)
        {
            if (gameObjectList.ContainsKey(gameObjectName))
            {
                count = gameObjectList.Count + 1;
                gameObjectList.Add(gameObjectName + count, new GameObject(gameObjectName + count));
            }
            else
            {
                gameObjectList.Add(gameObjectName, new GameObject(gameObjectName));
            }
            
        }

        public static void AddEmpty()
        {
            count = gameObjectList.Count + 1;
            gameObjectList.Add("Default_GameObject_" + count, new GameObject("Default_GameObject_" + count));
        }*/

        public static void Remove(string gameObjectName)
        {
            if (gameObjectList.ContainsKey(gameObjectName))
            {
                gameObjectList.Remove(gameObjectName);
            }
            else
            {
                Console.WriteLine("Does not exist");
            }
        }

    }
}
