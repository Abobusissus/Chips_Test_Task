using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Ttask
{
    internal class Program
    {

        static int  MaxF(int[] chips, int amount_of_players) //search for index with maximal value in array 
        {   
            
            int Max = 1;
            int Max_ID = 0;

            for (int i = 0; i < amount_of_players; i++)
            {
                if (chips[i] >= Max)
                {
                    Max = chips[i];
                    Max_ID = i;
                }
            }
            return Max_ID;

        }

        static int MinF(int[] chips, int amount_of_players) //search for index with minimal value in array
        {
            int Min = 1;
            int Min_ID = 0;
            for (int i = 0; i < amount_of_players; i++)
            {
                if (chips[i] <= Min)
                {
                    Min = chips[i];
                    Min_ID = i;
                }
                
            }
                return Min_ID;
        }
        static void Main(string[] args)
        {


            Console.Write("Enter amount of chips for each player, separate by commas \n");
            string[] inputstr = Console.ReadLine().Split(','); 

            int amount_of_players = inputstr.Length;
            int[] chips = new int[amount_of_players];

            

            for (int i = 0; i < amount_of_players; i++) 
            {
                chips[i] = Convert.ToInt32(inputstr[i]); //fill an array 

            }
            int amount_of_chips  = chips.Sum(); 
            int amount_of_moves = 0; // counter variable
            

            if (amount_of_chips % amount_of_players != 0) //check for possibility of even distribution
            {
                Console.WriteLine("Chips cannot be evenly distributed");
                Console.ReadLine();
                return;
            }

            int avg = amount_of_chips / amount_of_players; //calculate amount of cheaps for each seat

            int sort_count = chips.Where(x => x != null && x.Equals(avg)).Count(); //variable sort count cantains amount of seats which have right amount of chips 

                while (sort_count != chips.Count())
                {
                    int Max_ID = MaxF(chips, amount_of_players);
                    int Min_ID = MinF(chips, amount_of_players);
                if (Min_ID < Max_ID) 
                {
                    if (Max_ID - Min_ID > amount_of_players / 2) // check for shortest path to minimal value 
                    {
                        chips[Max_ID]--; 
                        if(Max_ID != amount_of_players - 1)
                        {
                            chips[Max_ID+1]++;
                        }
                        else
                        {
                            chips[0]++;
                        }
                    }
                    else if (Max_ID - Min_ID <= amount_of_players / 2) 
                    {
                        chips[Max_ID]--;
                        if (Max_ID != 0)
                        {
                            chips[Max_ID-1]++;
                        }
                        else
                        {
                            chips[amount_of_players-1]++;
                        }
                    }
                }
                    if(Min_ID > Max_ID) 
                    {
                        if (Max_ID - Min_ID > amount_of_players / 2)
                        {
                            chips[Max_ID]--;
                            if (Max_ID != 0)
                            {
                                chips[Max_ID - 1]++;
                            }
                            else
                            {
                                chips[amount_of_players - 1]++;
                            }
                        }
                        else if (Max_ID - Min_ID <= amount_of_players / 2)  
                    {
                            chips[Max_ID]--;
                            if (Max_ID != amount_of_players - 1)
                                {
                                    chips[Max_ID + 1]++;
                                }
                            else
                                {
                                chips[0]++;
                                }
                        }


                    }

                    sort_count = chips.Where(x => x != null && x.Equals(avg)).Count(); // update variable 

                    amount_of_moves++; 

                }

             
            Console.WriteLine($"Chips for each seat  {avg} ");
            Console.WriteLine($"Chips  {amount_of_chips} ");
            Console.WriteLine($"Chips can be sorted in {amount_of_moves} moves");
            Console.ReadLine();
        }
    }
}
        

