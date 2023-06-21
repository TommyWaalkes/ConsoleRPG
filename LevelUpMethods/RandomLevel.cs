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
            while (s._canLevel)
            {
                s.Level++;
                s.HpMax = g.Hp * s.Level;
                s.HpCurrent = s.HpMax;

                s.Attack += r.Next(1, g.Attack + 1);
                s.Defense += r.Next(1, g.Defense + 1);
                s.Speed += r.Next(1, g.Speed + 1);
                s.Luck += r.Next(1, g.Luck + 1);
                s.Intelligence += r.Next(1, g.Intelligence + 1);
            }
        }
    }
}
