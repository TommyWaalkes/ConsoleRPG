using RPGConsoleGame.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.LevelUpMethods
{
    internal class LinearLevel : LevelUpStats
    {
        public override void newLevel(Growths g, Stats s, Job j)
        {
            s.Attack += g.Attack;
            s.Defense+= g.Defense;
            s.Speed += g.Speed;
            s.Luck+= g.Luck;
            s.Intelligence += g.Intelligence;
            s.HpMax += g.Hp;
            s.HpCurrent = s.HpMax;
        }
    }
}
