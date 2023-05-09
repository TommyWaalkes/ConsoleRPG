using RPGConsoleGame.Jobs;
using RPGConsoleGame.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Factions
{
    public abstract class Faction
    {
        public List<Job> AllowedJobs { get; set; }
        public List<Race> AllowedRaces { get; set; }

        public Stats InitialStats { get; set; }
        public Growths InitialGrowths { get; set; }

        public Faction(List<Job> allowedJobs, List<Race> allowedRaces)
        {
            AllowedJobs = allowedJobs;
            AllowedRaces = allowedRaces;
        }

        public abstract void ApplyFactionFeatures(Player p);
    }
}
