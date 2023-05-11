using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Races
{
    internal class Human : Race
    {
        public Human() : base("Human", "")
        {
            SetStats(1,1,1,4,1,1,1,1);
            SetGrowths(1, 1, 1, 1, 1, 1, 1);
        }
    }
}
