using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Skills
{
    public class Buff : Skill
    {
        public int Duration { get; set; } = 1;
        public int Bonus { get; set; } = 1; 
        public int CastLevel { get; set; } = 1;
        public List<Stat> StatsAffected { get; set; } = new List<Stat>();

        public Buff(int Duration, int Bonus,  int CastLevel, params Stat[] StatsAffected)
        {
            this.Duration = Duration;
            this.Bonus = Bonus;
            this.StatsAffected = StatsAffected.ToList();
            this.CastLevel = CastLevel;
        }

        public override void Effect(Player caster, params Player[] targets)
        {
            foreach(Player p in targets)
            {
                foreach(Stat stat in StatsAffected)
                {
                    switch(stat)
                    {
                        case Stat.Attack:
                            p.Stats.Attack += GetBonusFormula(caster.Stats.Intelligence);
                            break;
                        case Stat.Defense:
                            p.Stats.Defense += GetBonusFormula(caster.Stats.Intelligence);
                            break;
                    }
                }
            }
        }

        public int GetBonusFormula(int casterStats)
        {
           return (Bonus + casterStats) * CastLevel + 1;
        }
    }
}
