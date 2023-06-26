using RPGConsoleGame.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.LevelUpMethods
{
    //This is for stats 
    internal class RandomLevel : LevelUpStats
    {
        public override void newLevel(Growths g, Stats s, Job j)
        {
            Random r = new Random();
            int min = s.Luck / 10;
            while (s._canLevel)
            {
                s.Level++;
                s.HpMax = g.Hp * s.Level;
                s.HpCurrent = s.HpMax;

                s.Attack += r.Next(1+min, g.Attack + 1 +min);
                s.Defense += r.Next(1+min, g.Defense + 1 + min);
                s.Speed += r.Next(1 +min, g.Speed + 1 +min);
                s.Luck += r.Next(1 + min, g.Luck + 1+min);
                s.Intelligence += r.Next(1 + min, g.Intelligence + 1 + min);
            }
        }
    }
}
