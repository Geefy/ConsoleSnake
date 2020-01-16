using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Snake
{
    class Food 
    {
        Random rnd = new Random(DateTime.Now.Millisecond);
        public int foodYPos = 3;
        public int foodXPos = 2;

        public bool spawned = false;

       

        public void SpawnFood()
        {
            if (this.spawned == false)
            {
                foodYPos = rnd.Next(1, GameMap.yAxisMap);
                foodXPos = rnd.Next(1, GameMap.xAxisMap);
                this.spawned = true;

            }

            Console.SetCursorPosition(foodXPos, foodYPos);
            Console.Write("■");
            return;

        }

    }
}
