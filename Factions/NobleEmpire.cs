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
        public NobleEmpire(List<Job> allowedJobs, List<Race> allowedRaces) : base(allowedJobs, allowedRaces, 
            new Stats(0,0,0,0,0,0,0,0,0,0), 
            new Growths(1,1,1,3,0,0,0))
        {
        }

        public override void ApplyFactionFeatures(Player p)
        {
            p.Stats = Stats.CombineStats(InitialStats, p.Stats);
            p.Growths = Growths.CombineGrowths(InitialGrowths, p.Growths);
        }
    }
}
