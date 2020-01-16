using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Snake
{
    class Program
    {

        static void Main(string[] args)
        {
            PlayerSnake player = new PlayerSnake();

            Console.SetWindowSize(GameMap.xAxisMap, GameMap.yAxisMap);
            Console.CursorVisible = false;
            while (player.gameOver == false)
            {
                if (GameMap.UpdateGame())
                {
                    player.DrawPlayer();
                    player.Movement();
                }
            }
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Game Over!");
            Console.WriteLine("Final Score: " + player.score);
            Console.Read();


        }


    }
}
