using RPGConsoleGame.Jobs;
using RPGConsoleGame.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Encounter
{
    internal class Choice
    {
        public bool canPick { get; set; } = true;
        public bool restrictJobs { get; set; } = false;
        public bool restrictRaces { get; set; } = false; 
        public bool restrictLevel { get; set; } = false;
        public bool restrictStats { get; set; } = false;
        public Dictionary<Stat, int> statRequirements { get; set; } = new Dictionary<Stat, int>();
        public List<Job> allowedJobs { get; set; } = new List<Job>();
        public List<Race> allowedRaces { get; set; } = new List<Race>();
        public int LevelRequired { get; set; } = 0; 
        public string Message { get; set; }

        public Choice( List<Job> allowedJobs, List<Race> allowedRaces, int levelRequired, string message)
        {
            this.allowedJobs = allowedJobs;
            this.allowedRaces = allowedRaces;
            LevelRequired = levelRequired;
            Message = message;
        }

        public void SetCanPick(Player p)
        {
            bool rightLevel = true; 
            if (restrictLevel)
            {
                rightLevel = p.Stats.Level >= LevelRequired;
            }

            bool rightJob = true;
            if (restrictJobs)
            {
                rightJob = allowedJobs.Contains(p.Job);
            }

            bool rightRace = true;
            if (restrictRaces)
            {
                rightRace = allowedRaces.Contains(p.Race);
            }

            bool rightStats = true;
            if (restrictStats)
            {
                //go through the dictionary 
                foreach(Stat key in statRequirements.Keys)
                {
                    int stat = p.Stats.GetStat(key);
                    int requiredStat = statRequirements[key]; 

                    if(stat< requiredStat)
                    {
                        rightStats = false;
                        break;
                    }
                }
            }

          canPick = rightLevel && rightJob && rightRace && rightStats;
        }
    }
}
