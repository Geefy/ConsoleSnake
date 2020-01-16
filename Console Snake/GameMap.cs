using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Snake
{
    class GameMap
    {

        public static int xAxisMap = 60;
        public static int yAxisMap = 30;
        public static int gameSpeed = 100;
        private static DateTime nextUpdate = DateTime.MinValue;

        public static bool UpdateGame()
        {
            if (DateTime.Now < nextUpdate) return false;

            nextUpdate = DateTime.Now.AddMilliseconds(gameSpeed);
            
            return true;
            
        }

    }
}
