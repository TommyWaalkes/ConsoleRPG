using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Jobs
{
    internal class Cleric : Job
    {
        public Cleric() : base("Fighter", "Fight stuff")
        {
            SetStats(10, 2, 3, 12, 8, 2, 5, 5);
            SetGrowths(3, 1, 1, 8, 1, 4, 2);
            Attacks.Add(new Attack("Mace", DamageType.Blunt, 4, 8));
        }
    }
}
