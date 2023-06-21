using RPGConsoleGame.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.LevelUpMethods
{
    public abstract class LevelUpStats
    {
        public abstract void newLevel(Growths g, Stats s, Job j);
    }
}
