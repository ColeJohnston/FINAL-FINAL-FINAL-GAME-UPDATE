using System;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;

namespace players
{
    struct players
    {
        public string name;
        public int score;
        public double time;

        public players(string name, int score, double time)
        {
            this.name = name;
            this.score = score;
            this.time = time;
        }

        public string getName()
        {
            return this.name;
        }
        public int getScore()
        {
            return this.score;
        }

        public double getTime()
        {
            return this.time;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            int[] player = new int[2], treasure = new int[2];
            string[,] position = new string[3, 3];
            int level = 1;
            Intro();
            player = playerStartingLocation();
            treasure = treasureStartingLocation(player);
            position = initializeMap(player, treasure);
            while (true)
            {
                switch (level)
                {
                    case 1:
                        map134(position);
                        Console.WriteLine(player[0] + ", " + player[1]);
                        position[player[0], player[1]] = "X";
                        player = playerUpdate134(player, keyPress(), position, treasure);
                        Console.Clear();
                        if (player[0] == treasure[0] && player[1] == treasure[1])
                        {
                            Console.Write("WOOOOOOOOOOOOOO");
                            level++;
                            Console.ReadLine();
                            player = playerStartingLocation();
                            treasure = treasureStartingLocation(player);
                            foreach (int i in player)
                            {
                                Console.Write(i + " ");
                            }
                            Console.WriteLine();
                            foreach (int i in treasure)
                            {
                                Console.Write(i + " ");
                            }
                            position = initializeMap(player, treasure);
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine(player[0] + ", " + player[1]);
                        position[player[0], player[1]] = "X";
                        map2(position);
                        player = playerUpdate2(player, keyPress(), position, treasure);
                        Console.Clear();
                        if (player[0] == treasure[0] && player[1] == treasure[1])
                        {
                            Console.Write("WOOOOOOOOOOOOOO");
                            level++;
                            Console.ReadLine();
                        }
                        break;
                }
            }


        }
        static void Intro()
        {
            Console.WriteLine("Instructions ");
            Console.WriteLine("--------------------------------------------");
            Console.Write("-Navigate to the ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Treasure ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("while avoiding barriers and ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("deadly ghosts ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nwhich can pass through walls, the treasure, and even each other.");
            Console.WriteLine("\n-You are given 3 lives total");
            Console.WriteLine("\n-Each time you lose a life, you restart the current level");
            Console.WriteLine("\n-If you lose all 3 lives, you will be forced to start over");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\n-Score ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("is calculated by speed and lives remaining");
            Console.WriteLine("\nPress Enter to see map key");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("KEY");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("X - You");
            Console.WriteLine("/ - Barrier");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("* - Treasure");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("! - Deadly Ghosts");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress enter when you think you're ready");
            Console.ReadLine();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
        }
        static int[] playerStartingLocation()
        {
            return randomizer();
        }
        static int[] treasureStartingLocation(int[] player)
        {
            int[] start = new int[2];
            do
            {
                start = randomizer();
            } while (start[0] == player[0] && start[1] == player[1]);
            return start;
        }
        static int[] ghost1StartingLocation()
        {
            return randomizer();
        }
        static int[] ghost2StartingLocation()
        {
            return randomizer();
        }
        static string[,] initializeMap(int[] player, int[] tStart)
        {
            string[,] position = new string[3, 3];
            for (int i = 0; i < position.GetLength(0); i++)
            {
                for (int j = 0; j < position.GetLength(1); j++)
                {
                    position[i, j] = "_";
                }
            }
            position[player[0], player[1]] = "X";
            position[tStart[0], tStart[1]] = "*";


            return position;
        }
        static void map134(string[,] position)
        {
            Console.WriteLine(" --------- --------- --------- ");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|    " + position[0, 0] + "    |    " + position[0, 1] + "    |    " + position[0, 2] + "    |");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|--------- --------- ---------");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|    " + position[1, 0] + "    |    " + position[1, 1] + "    |    " + position[1, 2] + "    |");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine(" --------- --------- ---------");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|    " + position[2, 0] + "    |    " + position[2, 1] + "    |    " + position[2, 2] + "    |");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine(" --------- --------- ---------");
        }
        static void map2(string[,] position)
        {
            Console.WriteLine(" --------- --------- --------- ");
            Console.WriteLine("|         /         |         |");
            Console.WriteLine("|    " + position[0,0] + "    /    " + position[0,1] + "    |    " + position[0,2] + "    |");
            Console.WriteLine("|         /         |         |");
            Console.WriteLine("|--------- ///////// ---------");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|    " + position[1,0] + "    |    " + position[1,1] + "    |    " + position[1,2] + "    |");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine(" --------- --------- /////////");
            Console.WriteLine("|         /         |         |");
            Console.WriteLine("|    " + position[2,0] + "    /    " + position[2,1] + "    |    " + position[2,2] + "    |");
            Console.WriteLine("|         /         |         |");
            Console.WriteLine(" --------- --------- ---------");
        }
        static void map5(string[,] position)
        {
            Console.WriteLine(" --------- --------- --------- ");
            Console.WriteLine("|         /         /         |");
            Console.WriteLine("|    " + position[0,0] + "    /    " + position[0,1] + "    /    " + position[0,2] + "    |");
            Console.WriteLine("|         /         /         |");
            Console.WriteLine("|--------- --------- ---------");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|    " + position[1,0] + "    |    " + position[1,1] + "    |    " + position[1,2] + "    |");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine(" --------- --------- /////////");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine("|    " + position[2,0] + "    |    " + position[2,1] + "    |    " + position[2,2] + "    |");
            Console.WriteLine("|         |         |         |");
            Console.WriteLine(" --------- --------- ---------");
        }

        static string keyPress()
        {
            ConsoleKeyInfo keyInfo;
            keyInfo = Console.ReadKey(true);
            string movement = "";
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    movement = "UP";
                    PerformEnter();
                    break;
                case ConsoleKey.DownArrow:
                    movement = "DOWN";
                    PerformEnter();
                    break;
                case ConsoleKey.LeftArrow:
                    movement = "LEFT";
                    PerformEnter();
                    break;
                case ConsoleKey.RightArrow:
                    movement = "RIGHT";
                    PerformEnter();
                    break;
            }
            static void PerformEnter()
            {
                Console.Write("\r\n"); // Send a carriage return (Enter key)
            }
            return movement;
        }
        static int[] randomizer()
        {
            Random res = new Random();
            int[] i = new int[2];
            i[0] = res.Next(3);
            i[1] = res.Next(3);
            return i;
        }

        static int[] playerUpdate134(int[] player, string keyPress, string[,] position, int[] treasure)
        {
            position[player[0], player[1]] = "_";
            int[] newCoordinates = new int[2];
            if (keyPress == "UP" && player[0] != 0)
            {
                player[0]--;
            }
            else if (keyPress == "DOWN" && player[0] != 2)
            {
                player[0] ++;
            }
            else if (keyPress == "RIGHT" && player[1] != 2)
            {
                player[1]++;
            }
            else if (keyPress == "LEFT" && player[1] != 0)
            {
                player[1]--;
            }
            Console.WriteLine("OUT");
            position[player[0], player[1]] = "X";
            position[treasure[0], treasure[1]] = "*";
            return player;
        }
        static int[] playerUpdate2(int[] player, string keyPress, string[,] position, int[] treasure)
        {
            position[player[0], player[1]] = "_";
            int[] newCoordinates = new int[2];
            if (keyPress == "UP" && player[0] != 0 && !(player[0] == 1 && player[1] == 1) && !(player[0] == 2 && player[1] == 2))
            {
                player[0]--;
            }
            else if (keyPress == "DOWN" && player[0] != 2 && !(player[0] == 0 && player[1] == 1) && !(player[0] == 1 && player[1] == 2))
            {
                player[0]++;
            }
            else if (keyPress == "RIGHT" && player[1] != 2 && !(player[0] == 0 && player[1] == 0) && !(player[0] == 2 && player[1] == 0))
            {
                player[1]++;
            }
            else if (keyPress == "LEFT" && player[1] != 0 && !(player[0] == 0 && player[1] == 1) && !(player[0] == 2 && player[1] == 1))
            {
                player[1]--;
            }
            Console.WriteLine("OUT");
            position[player[0], player[1]] = "X";
            position[treasure[0], treasure[1]] = "*";
            return player;
        }
    }
}