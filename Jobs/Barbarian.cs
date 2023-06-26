using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Jobs
{
    internal class Barbarian : Job
    {
        public Barbarian() : base("Barbarian", "Fight stuff")
        {
            SetStats(1, 6, 6, 12, 10, 8, 0, 1);
            SetGrowths(1, 4, 1, 6, 2, 0, 1);
            Attacks.Add(new Attack("Axe", DamageType.Slashing, 2, 12));
        }
    }
}
