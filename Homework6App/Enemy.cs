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
                            if (IsEnemyPositionAvailable(Map, xPos, yPos, 0, -1))
                            {
                                SetEnemyToPosition(Map, xPos, yPos, 0, -1);
                            }
                            else
                            {
                                EnemyDirection = 0;
                            }
                            break;
                        }
                    case 2:
                        {

                            if (IsEnemyPositionAvailable(Map, xPos, yPos, -1, 0))
                            {
                                SetEnemyToPosition(Map, xPos, yPos, -1, 0);
                            }
                            else
                            {
                                EnemyDirection = 0;
                            }
                            break;
                        }
                    case 3:
                        {

                            if (IsEnemyPositionAvailable(Map, xPos, yPos, 0, 1))
                            {
                                SetEnemyToPosition(Map, xPos, yPos, 0, 1);
                            }
                            else
                            {
                                EnemyDirection=0;
                            }
                            break;
                        }
                    case 4:
                        {

                            if (IsEnemyPositionAvailable(Map, xPos, yPos, 1, 0))
                            {
                                SetEnemyToPosition(Map, xPos, yPos, 1, 0);
                            }
                            else
                            {
                                EnemyDirection=0;
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            
            }
            static bool IsEnemyPositionAvailable(Cell[,]Map, int xPos, int yPos, int xDelta, int yDelta)
            {
                bool isInBounds = true;

                int newPosX = xPos + xDelta;
                int newPosY = yPos + yDelta;

                if (xPos + xDelta < 0 || xPos + xDelta >= Map.GetLength(0) ||
                    yPos + yDelta < 0 || yPos + yDelta >= Map.GetLength(1))
                {
                    isInBounds = false;
                }
                return isInBounds && Map[newPosX, newPosY].CanMove;
            }
            static void SetEnemyToPosition(Cell[,]Map, int xPos, int yPos, int xDelta, int yDelta)
            {
                int newPosX = xPos + xDelta;
                int newPosY = yPos + yDelta;

                Map[xPos, yPos].Reset();
                Map[newPosX, newPosY].SetEnemy('☻');

                xPos = newPosX;
                yPos = newPosY;

            }
        }
    
    }
}
