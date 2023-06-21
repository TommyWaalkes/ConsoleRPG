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

        public override void ApplyLevelUp(Player p, int level)
        {
            p.Stats.Attack += 2;
            switch(level)
            {
                case 2:
                    string input = GetUserInput("Would you like 1)5+ Attack and Speed or 2)5+ Defense and HP: 1 or 2", new List<string>() { "1", "2" });
                    if(input== "1")
                    {
                        p.Stats.Attack += 5;
                        p.Stats.Speed+= 5;
                    }
                    else
                    {
                        p.Stats.Defense += 5; 
                        p.Stats.HpMax += 5;
                        p.Stats.HpCurrent += 5;
                    }
                    break;
                
            }
        }

       
    }
}
