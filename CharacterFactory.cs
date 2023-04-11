using RPGConsoleGame.Jobs;
using RPGConsoleGame.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame
{
    internal class CharacterFactory
    {
        public List<Race> Races = new List<Race>();
        public List<Job> Jobs = new List<Job>();

        public CharacterFactory()
        {
            Jobs.Add(new Fighter());
            Races.Add(new Human());

        }
        public  Player CreateByHand(int level)
        {
            
            Console.WriteLine("Please select a race you'd wish to use");
            PrintRaces();
            int pick = int.Parse(Console.ReadLine());
            Race r = Races[pick];

            Console.WriteLine();
            Console.WriteLine("Next Select a job you'd wish to use");
            PrintJobs(); 
            int pick2 = int.Parse(Console.ReadLine());
            Job j = Jobs[pick2];
            Console.WriteLine("Lastly name your character:");
            string name = Console.ReadLine();

            Player p = new Player(j, r, name);
            p.Stats.Level = level;
            Console.WriteLine("Go with this character? y/n");
            p.PrintCharacterSheet();
            string response = "";
            while(response.Trim().ToLower() != "y" || response != "n")
            {
                response = Console.ReadLine();
                if(response == "y" || response =="n")
                {
                    break;
                }
            }

            if(response == "y" ) {
                return p;
            }
            else
            {
                return CreateByHand(1);
            }

            
        }

        public  Player GenerateRandom(int level)
        {
            Random r = new Random(); 
            int jPick = r.Next(0, Jobs.Count);
            int rPick = r.Next(0, Races.Count);

            Job j = Jobs[rPick];
            Race ra = Races[rPick];
            Player player = new Player(j, ra, "Smeef");
            return player;
        }

        public  void PrintRaces()
        {
            for(int i = 0; i < Races.Count; i++)
            {
                Console.WriteLine($"{i}:{Races[i].Name}");
            }
        }

        public void PrintJobs()
        {
            for (int i = 0; i < Jobs.Count; i++)
            {
                Console.WriteLine($"{i}:{Jobs[i].Name}");
            }
        }
    }
}
