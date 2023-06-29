using RPGConsoleGame.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.LevelUpMethods
{
    internal class PickLevelUp : LevelUpStats
    {
        int increase = 2;
        bool randomize = false;
        public override void newLevel(Growths g, Stats s, Job j)
        {
            int points = 5 + s.Intelligence / 4;
            while(points > 0)
            {
                if(randomize)
                {
                    Random r = new Random();
                    increase = r.Next(1, 5);
                }
                Console.WriteLine("Which stat would you like to pick?");
                Stat[] statsValues = (Stat[])Enum.GetValues(typeof(Stat));
                Console.WriteLine("Current Stats:");
                s.PrintStats();
                for (int i = 0; i < statsValues.Length; i++)
                {
                    Console.WriteLine($"{i}: {statsValues[i]}");
                }
                try
                {
                    int pick = int.Parse(Console.ReadLine());
                    Stat stat = statsValues[pick];
                    switch(stat)
                    {
                        case Stat.Attack:
                            s.Attack+= increase;
                            break;
                        case Stat.Defense:
                            s.Defense += increase;
                            break;
                        case Stat.Speed:
                            s.Speed += increase;
                            break;
                    }

                }
                catch (Exception e)
                {

                }
                points--;
            }

        }
    }
}
