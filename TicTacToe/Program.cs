using System;
using System.Threading;
using System.Linq;

namespace TicTacToe
{
    class Program
    {
        static char[] Spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int Player = 1;
        static bool Won = false;
        static void Draw()
        {
            Console.WriteLine("      |       |      ");
            Console.WriteLine("   {0}  |   {1}   |  {2} ", Spaces[0], Spaces[1], Spaces[2]);
            Console.WriteLine("______|_______|______");
            Console.WriteLine("      |       |      ");
            Console.WriteLine("   {0}  |   {1}   |  {2} ", Spaces[3], Spaces[4], Spaces[5]);
            Console.WriteLine("______|_______|______");
            Console.WriteLine("      |       |      ");
            Console.WriteLine("   {0}  |   {1}   |  {2} ", Spaces[6], Spaces[7], Spaces[8]);
            Console.WriteLine("      |       |      ");
        }
        static void DrawX(int pos)
        {
            Spaces[pos] = 'X';
        }
        static void DrawO(int pos)
        {
            Spaces[pos] = 'O';
        }
        static void Check()
        {
            if (Spaces[0] == Spaces[1] && Spaces[1] == Spaces[2] ||
                Spaces[3] == Spaces[4] && Spaces[4] == Spaces[5] ||
                Spaces[6] == Spaces[7] && Spaces[7] == Spaces[8] ||
                Spaces[0] == Spaces[3] && Spaces[3] == Spaces[6] ||
                Spaces[1] == Spaces[4] && Spaces[4] == Spaces[7] ||
                Spaces[2] == Spaces[5] && Spaces[5] == Spaces[8] ||
                Spaces[6] == Spaces[4] && Spaces[4] == Spaces[2] ||
                Spaces[0] == Spaces[4] && Spaces[4] == Spaces[8]
                )
            {
                Won = true;
            }
            else if (Spaces.All(x => x == 'X' | x == 'O'))
            {
                Console.WriteLine("No win possible");
                Thread.Sleep(5000);
                Environment.Exit(1);
            }

            
            
        }

        static void Main(string[] args)
        {
            while (Won == false)
            {
                Console.WriteLine($"Choose your postition player {Player}");
                Draw();
                int? pos = 0;
                try
                {
                    
                    Console.Write("\n\rYour selection: ");
                    pos = Convert.ToInt32(Console.ReadLine()) -1;

                }
                catch (Exception)
                {
                
                    Console.WriteLine("Invalid selection"); 
                }
                if(Player == 1)
                {
                    DrawX((int)pos);
                }
                else
                {
                    DrawO((int)pos);
                }
                Console.Clear();
                Player = Player == 1 ? 2 : 1;
                Check();
                if (Won == true)
                {
                    Console.WriteLine($"You win Player {Player}");
                    Thread.Sleep(5000);
                }
                Draw();
                
            }
        }
    }
}
