using System;

namespace Homework6App
{
    class Program
    {
        static Player Player = new Player();
        static Enemy Enemy1 = new Enemy();
        static Enemy Enemy2 = new Enemy();
        static Enemy Enemy3 = new Enemy();
        static Cell[,] Map = new Cell[15, 15];
        static int turnCount = 0;

        static void Main(string[] args)
        {
            GenerateMap();
            // set player to init position
            Map[1, 1].SetPlayer(Player.Char);
            Map[10, 10].SetEnemy(Enemy1.Char);
            Map[3, 10].SetEnemy(Enemy1.Char);
            Map[10, 3].SetEnemy(Enemy1.Char);
            Player.xPos = 1;
            Player.yPos = 1;
            Enemy1.xPos = 10;
            Enemy1.yPos = 3;
            Enemy1.xPos = 10;
            Enemy1.yPos = 10;
            Enemy1.xPos = 10;
            Enemy1.yPos = 3;
            RenderMap();

            while (Player.isAlive)
            {
                turnCount++;
                bool isInputSuccess;

                do
                {
                    ConsoleKey key = Console.ReadKey().Key;
                    isInputSuccess = true;

                    switch (key)
                    {
                        case ConsoleKey.A:
                            {
                                if (IsPositionAvailable(0, -1))
                                {
                                    SetPlayerToPosition(0, -1);
                                }
                                else
                                {
                                    Console.WriteLine("Position is unavailable");
                                    isInputSuccess = false;
                                }
                                break;
                            }
                        case ConsoleKey.W:
                            {

                                if (IsPositionAvailable(-1, 0))
                                {
                                    SetPlayerToPosition(-1, 0);
                                }
                                else
                                {
                                    Console.WriteLine("Position is unavailable");
                                    isInputSuccess = false;
                                }
                                break;
                            }
                        case ConsoleKey.D:
                            {

                                if (IsPositionAvailable(0, 1))
                                {
                                    SetPlayerToPosition(0, 1);
                                }
                                else
                                {
                                    Console.WriteLine("Position is unavailable");
                                    isInputSuccess = false;
                                }
                                break;
                            }
                        case ConsoleKey.S:
                            {

                                if (IsPositionAvailable(1, 0))
                                {
                                    SetPlayerToPosition(1, 0);
                                }
                                else
                                {
                                    Console.WriteLine("Position is unavailable");
                                    isInputSuccess = false;
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Wrong key, use \"W,A,S,D\"");
                                isInputSuccess = false;
                                break;
                            }
                    }
                    Enemy1.EnemyMove(Map, Enemy1.xPos, Enemy1.yPos);
                    RenderMap();
                    Enemy2.EnemyMove(Map, Enemy2.xPos, Enemy2.yPos);
                    RenderMap();
                    Enemy3.EnemyMove(Map, Enemy3.xPos, Enemy3.yPos);
                    RenderMap();
                }
                while (!isInputSuccess);

                RenderMap();
            }
        }

        static void GenerateMap()
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int k = 0; k < Map.GetLength(1); k++)
                {
                    Map[i, k] = new Cell(i, k);
                }
            }
        }

        static void RenderMap()
        {
            Console.Clear();
            Console.WriteLine($"Turn count: {turnCount}");
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                Console.WriteLine(new string('-', Map.GetLength(1) * 4 + 1));
                Console.Write("|");
                for (int k = 0; k < Map.GetLength(1); k++)
                {
                    if (Map[i, k].IsPlayerKeeper)
                    {
                        ToConsole(Map[i, k].ToString(), ConsoleColor.Yellow);
                        Console.Write("|");
                    }
                    else if (Map[i, k].IsEnemyKeeper)
                    {
                        ToConsole(Map[i, k].ToString(), ConsoleColor.Red);
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write($"{Map[i, k]}|");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', Map.GetLength(1) * 4 + 1));
        }

        /// <summary>
        /// Use before calling SetPlayerToPosition
        /// </summary>
        /// <param name="mDelta"></param>
        /// <param name="nDelta"></param>
        /// <returns></returns>
        static bool IsPositionAvailable(int xDelta, int yDelta)
        {
            bool isInBounds = true;

            int newPosX = Player.xPos + xDelta;
            int newPosY = Player.yPos + yDelta;

            if (Player.xPos + xDelta < 0 || Player.xPos + xDelta >= Map.GetLength(0) ||
                Player.yPos + yDelta < 0 || Player.yPos + yDelta >= Map.GetLength(1))
            {
                isInBounds = false;
            }
            return isInBounds && Map[newPosX, newPosY].CanMove;
        }

        /// <summary>
        /// Only for move actions, Exception if !IsPositionAvailable
        /// </summary>
        /// <param name="mDelta"></param>
        /// <param name="nDelta"></param>
        static void SetPlayerToPosition(int xDelta, int yDelta)
        {
            int newPosX = Player.xPos + xDelta;
            int newPosY = Player.yPos + yDelta;

            Map[Player.xPos, Player.yPos].Reset();
            Map[newPosX, newPosY].SetPlayer(Player.Char);

            Player.xPos = newPosX;
            Player.yPos = newPosY;
        }


        public static void ToConsole(string str, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ResetColor();
        }

        




    }
}
