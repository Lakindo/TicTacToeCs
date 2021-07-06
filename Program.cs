using System;
using System.Threading;

namespace TicTacToe1
{
    class Program
    {
        static int player = 1;
        static int choice;
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int gamestate = 0;

        private static void BoardPrinter()
        {
            var format = "{0} | {1} | {2} ";
            var separator = "  |   |  ";
            var lines = "__|___|__";


            Console.WriteLine(format, arr[1], arr[2], arr[3]);
            Console.WriteLine(lines);
            Console.WriteLine(separator);
            Console.WriteLine(format, arr[4], arr[5], arr[6]);
            Console.WriteLine(lines);
            Console.WriteLine(separator);
            Console.WriteLine(format, arr[7], arr[8], arr[9]);
            Console.WriteLine(separator);

        }

        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1 = X, Player 2 = O");
                Console.WriteLine("\n");

                if (player % 2 == 0)
                {

                    Console.WriteLine("P2 Turn\n");

                }

                else
                {

                    Console.WriteLine("P1 Turn\n");

                }

                BoardPrinter();

                choice = int.Parse(Console.ReadLine());


                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }

                else
                {
                    Console.WriteLine("Position already taken");
                    Console.WriteLine("\n");
                    Console.WriteLine("Reloading board...");
                    Thread.Sleep(1000);
                }

                gamestate = WinChecker();

            } while (gamestate != 1 && gamestate != -1);

            Console.Clear();

            BoardPrinter();

            if (gamestate == 1)
            {

                Console.WriteLine("Player {0} is victorious!\n", (player % 2) + 1);
            }
            else
            {

                Console.WriteLine("Draw");
            }

            Console.ReadLine();
        }

        private static int WinChecker()
        {
            //Horizontal

            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return 1;
            }

            //Diagonal

            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }

            //Vertical

            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }

            //Draw

            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5'
                && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }

            //Game still running

            else
            {
                return 0;
            }
        }
    }
}