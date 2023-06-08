using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Skills
{
    public class HealSkill : Skill
    {
        public HealSkill(string Name, string Description) : base(Name, Description) { }

        public override void Effect(Player caster, params Player[] targets)
        {
            foreach (Player p in targets)
            {
                int healAmount = caster.Stats.Intelligence * caster.Stats.Level * Magnitude + 1;
                p.Stats.HpCurrent += healAmount;

                if(p.Stats.HpCurrent > p.Stats.HpMax) { 
                    p.Stats.HpCurrent= p.Stats.HpMax;
                }
            }
        }
    }
}
