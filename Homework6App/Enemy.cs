using System;
using System.Collections.Generic;
using System.Text;

namespace Homework6App
{
    public class Enemy
    {
        public char Char;
        public int xPos { get; set; }
        public int yPos { get; set; }
        public char enemy { get; set; }

        public int newPosX { get; set; }
        public int newPosY { get; set; }

        public Enemy()
        {
            Char = '☻';
            xPos = 0;
            yPos = 0;
        }
        public void EnemyMove(Cell[,]Map, int xPos, int yPos)
        {
            int EnemyDirection = 0;
            while(EnemyDirection == 0)
            {
                Random rnd = new Random();
                EnemyDirection = rnd.Next(1, 4);

                switch (EnemyDirection)
                {
                    case 1:
                        {
                            if (IsEnemyPositionAvailable(Map, 0, -1))
                            {
                                SetEnemyToPosition(Map, 0, -1);
                                break;
                            }
                            else
                            {
                                EnemyDirection = 0;
                                continue;
                            }
                            
                        }
                    case 2:
                        {

                            if (IsEnemyPositionAvailable(Map, -1, 0))
                            {
                                SetEnemyToPosition(Map, -1, 0);
                                break;
                            }
                            else
                            {
                                EnemyDirection = 0;
                                continue;
                            }
                            
                        }
                    case 3:
                        {

                            if (IsEnemyPositionAvailable(Map, 0, 1))
                            {
                                SetEnemyToPosition(Map, 0, 1);
                                break;
                            }
                            else
                            {
                                EnemyDirection=0;
                                continue;
                            }
                            
                        }
                    case 4:
                        {

                            if (IsEnemyPositionAvailable(Map, 1, 0))
                            {
                                SetEnemyToPosition(Map, 1, 0);
                                break;
                            }
                            else
                            {
                                EnemyDirection=0;
                                continue;
                            }
                            
                        }
                }
            
            }
            
        }
        public bool IsEnemyPositionAvailable(Cell[,] Map, int xDelta, int yDelta)
        {
            bool isInBounds = true;
            int count = 1;

            int newPosX = xPos + xDelta;
            int newPosY = yPos + yDelta;

            if (xPos + xDelta < 0 || xPos + xDelta >= Map.GetLength(0) ||
                yPos + yDelta < 0 || yPos + yDelta >= Map.GetLength(1))
            {
                isInBounds = false;
            }
            return isInBounds && Map[newPosX, newPosY].CanMove;
        }
        public void SetEnemyToPosition(Cell[,] Map, int xDelta, int yDelta)
        {
            int newPosX = xPos + xDelta;
            int newPosY = yPos + yDelta;

            Map[xPos, yPos].ResetEnemy();
            Map[newPosX, newPosY].SetEnemy(this.Char);

            xPos = newPosX;
            yPos = newPosY;
        }
    }
}
