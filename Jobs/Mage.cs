using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Jobs
{
    internal class Mage : Job
    {
        public Mage( ) : base("Mage", "Mage stuff")
        {
            SetStats(0, 5, 5, 5, 10, 5, 10, 2);
            SetGrowths(0, 1, 1, 2, 1, 2, 1);
            Attacks.Add(new Attack("Fieball", DamageType.Fire, 5, 10));
        }
    }
}
