using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Ttask
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.Write("Enter amount of chips for each player, separate by commas \n");
            string[] inputstr = Console.ReadLine().Split(',');

            int amount_of_players = inputstr.Length;
            int[] chips = new int[amount_of_players];

            int amount_of_chips = 0;
            int amount_of_moves = 0;

            for (int i = 0; i < amount_of_players; i++)
            {
                chips[i] = Convert.ToInt32(inputstr[i]);
                amount_of_chips += chips[i];
            }

            if (amount_of_chips % amount_of_players != 0)
            {
                Console.WriteLine("Chips cannot be evenly distributed");
                Console.ReadLine();
                return;
            }


            int Min = 1;
            int Max = 1;
            int Min_ID = 0;
            int Max_ID = 0;

            for (int i = 0; i < amount_of_players; i++)
            {
                if (chips[i] < Min)
                {
                    Min = chips[i];
                    Min_ID = i;
                }
                if (chips[i] > Max)
                {
                    Max = chips[i];
                    Max_ID = i;
                }
            }

            Console.WriteLine($"{Min} , {Max}");
            Console.WriteLine($"Chips can be sorted in {amount_of_moves} moves");
            Console.ReadLine();
        }
    }
}
        

