using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Jobs
{
    internal class Fighter : Job
    {
        public Fighter( ) : base("Fighter", "Fight stuff")
        {
            SetStats(3, 3, 3, 10, 10, 5, 0, 0);
            SetGrowths(2, 2, 1, 5, 1, 0, 0);
            Attacks.Add(new Attack("Sword", DamageType.Slashing, 2, 8));
        }
    }
}
