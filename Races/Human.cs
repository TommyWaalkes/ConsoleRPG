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
            SetStats(3, 3, 1, 20, 20, 10, 10, 10);
            SetGrowths(2, 2, 2, 2, 2, 2, 2);
        }
    }
}
