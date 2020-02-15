using System;
using System.Collections.Generic;

namespace threeDoors
{
    class Program
    {
        static void Main(string[] args)
        {
            int reps = 2000;
            int switchWins = 0;
            int switchLoss = 0;

            int stayWins = 0;
            int stayLoss = 0;
            SwitchDoors(ref switchWins, ref switchLoss, reps);
            StayDoors(ref stayWins, ref stayLoss, reps);

            double stayWinRatio = (stayWins / reps);
            double switchWinRatio = (switchWins / reps);

            
            Console.WriteLine("Repetitions: {0}", reps);
            Console.WriteLine("Switch doors\tWins: {0}\tLosses: {1}", switchWins, switchLoss);
            Console.WriteLine("Stay doors\tWins: {0}\t Losses: {1}", stayWins, stayLoss);
        }

        static void SwitchDoors(ref int switchWins, ref int switchLoss, int reps)
        {
            for(int i = 0; i < reps; ++i)
            {
                int count = 0;
                List<bool> doors = new List<bool>();
                int pick;
                bool firstCorrect = false;
                Random rand = new Random();
                int random = rand.Next(1, 1000);
                for(int j = random - 3; j < random; ++j)
                {
                    if(j% 3 == 0)
                    {
                        doors.Add(true);
                    }
                    else
                    {
                        doors.Add(false);
                    }
                    count++;
                }

                random = rand.Next(1, 1000);
                pick = random%3;

                if(doors[pick] == true)
                {
                    firstCorrect = true;
                }


                int otherFalse = 0;
                for(int j = 0; j < 3; j++)
                {
                    if(!doors[j] && j != pick)
                    {
                        otherFalse = j;
                    }
                }

                doors.Remove(doors[otherFalse]);
                for(int x = 0; x < 2; x++)
                {
                    if(!doors[x] && !firstCorrect)
                    {
                        pick = x;
                    }
                    else if(doors[x] && firstCorrect)
                    {
                        pick = x;
                    }
                }

                //Console.WriteLine("Pick (pre switch): {0}", pick);
                if(pick == 0)
                {
                    pick = 1;
                }
                else
                {
                    pick = 0;
                }

                //Console.WriteLine("Pick(post switch): {0}", pick);

                if(doors[pick])
                {
                    switchWins++;
                }
                else
                {
                    switchLoss++;
                }
            }
        }

        static void StayDoors(ref int stayWins, ref int stayLoss, int reps)
        {
            for(int i = 0; i < reps; ++i)
            {
                int count = 0;
                List<bool> doors = new List<bool>();
                int pick;
                bool firstCorrect = false;
                Random rand = new Random();
                int random = rand.Next(1, 1000);
                for(int j = random - 3; j < random; ++j)
                {
                    if(j% 3 == 0)
                    {
                        doors.Add(true);
                    }
                    else
                    {
                        doors.Add(false);
                    }
                    count++;
                }

                random = rand.Next(1, 1000);
                pick = random%3;

                if(doors[pick] == true)
                {
                    firstCorrect = true;
                }

                int otherFalse = 0;
                for(int j = 0; j < 3; j++)
                {
                    if(!doors[j] && j != pick)
                    {
                        otherFalse = j;
                    }
                }

                doors.Remove(doors[otherFalse]);
                for(int x = 0; x < 2; x++)
                {
                    if(!doors[x] && !firstCorrect)
                    {
                        pick = x;
                    }
                    else if(doors[x] && firstCorrect)
                    {
                        pick = x;
                    }
                }

                if(doors[pick])
                {
                    stayWins++;
                }
                else
                {
                    stayLoss++;
                }
            }
        }
    }
}
