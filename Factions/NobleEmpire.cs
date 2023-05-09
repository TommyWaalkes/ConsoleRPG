using RPGConsoleGame.Jobs;
using RPGConsoleGame.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Factions
{
    public class NobleEmpire : Faction
    {
        public NobleEmpire(List<Job> allowedJobs, List<Race> allowedRaces) : base(allowedJobs, allowedRaces)
        {
        }

        public override void ApplyFactionFeatures(Player p)
        {

        }
    }
}
