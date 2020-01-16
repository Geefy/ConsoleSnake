using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Console_Snake
{
    class PlayerSnake : GameMap
    {
        [DllImport("user32.dll")]
        static extern int GetAsyncKeyState(int vKeys);
        private static List<SnakePosition> positions = new List<SnakePosition>();

        public int score = 0;
        char snakeBody = '■';
        int snakeCount = 3;
        private SnakePosition startPos;
        Food currentFood = new Food();
        public bool gameOver = false;

        public enum Direction
        {
            right,
            left,
            up,
            down
        }


        public void DrawPlayer()
        {
            Console.Clear();
            foreach (SnakePosition position in positions)
            {
                Console.SetCursorPosition(position.snakeXPos, position.snakeYPos);
                Console.Write(snakeBody);
            }
            
            currentFood.SpawnFood();

        }

        public void Movement()
        {
            SnakePosition currentPos;

            if (positions.Count != 0)
            {
                currentPos = positions.Last();
            }
            else
            {
                currentPos = SetStartPosition(xAxisMap/ 2, yAxisMap / 2);
            }

            

            if (GetAsyncKeyState(0x25) != 0 && currentPos.direction != Direction.right)
            {
                currentPos.direction = Direction.left;
            }
            else if (GetAsyncKeyState(0x26) != 0 && currentPos.direction != Direction.down)
            {
                currentPos.direction = Direction.up;
            }
            else if (GetAsyncKeyState(0x27) != 0 && currentPos.direction != Direction.left)
            {
                currentPos.direction = Direction.right;
            }
            else if (GetAsyncKeyState(0x28) != 0 && currentPos.direction != Direction.up)
            {
                currentPos.direction = Direction.down;
            }

            switch (currentPos.direction)
            {
                case Direction.right:
                    currentPos.snakeXPos++;
                    break;
                case Direction.left:
                    currentPos.snakeXPos--;
                    break;
                case Direction.up:
                    currentPos.snakeYPos--;
                    break;
                case Direction.down:
                    currentPos.snakeYPos++;
                    break;
                default:
                    break;
            }

            if (currentPos.snakeYPos  < 0 || currentPos.snakeYPos > yAxisMap
               || currentPos.snakeXPos  < 0 || currentPos.snakeXPos > xAxisMap)
            {
                GameOver();
            }

            
            for (int i = 0; i < positions.Count ; i++)
            {
                if (currentPos.snakeXPos == positions.ElementAt(i).snakeXPos && currentPos.snakeYPos == positions.ElementAt(i).snakeYPos)
                {
                    GameOver();
                }
            }

            if (currentPos.snakeXPos == currentFood.foodXPos && currentPos.snakeYPos == currentFood.foodYPos)
            {
                snakeCount++;
                currentFood.spawned = false;
                score++;
                gameSpeed--;
                Console.Title = "Score: " + score;

            }
            positions.Add(currentPos);
            RemoveSnake();
        }

        private SnakePosition SetStartPosition(int xPos, int yPos)
        {
            startPos.snakeXPos = xPos;
            startPos.snakeYPos = yPos;
            startPos.direction = Direction.right;

            return startPos;
        }
        private void RemoveSnake()
        {
            while (positions.Count > snakeCount)
            {
                positions.Remove(positions.First());
            }
        }

        private struct SnakePosition
        {
            public int snakeYPos;
            public int snakeXPos;

            public Direction direction;
        }

        public void GameOver()
        {
            this.gameOver = true;
        }
       
    }
}