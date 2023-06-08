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

        public Buff(string Name, string Description, int Duration, int Bonus,  int CastLevel, params Stat[] StatsAffected) : base(Name, Description)
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
                List<KeyValuePair<Stat, int>> statsToMod = new List<KeyValuePair<Stat, int>>();
                foreach (Stat s in StatsAffected)
                {
                    int amount = GetBonusFormula(caster.Stats.Intelligence);
                    KeyValuePair<Stat, int> kvp = new KeyValuePair<Stat, int>(s, amount);
                    statsToMod.Add(kvp);
                }
                int duration = CalcDuration(caster);

                Effect e = new Effect(duration, statsToMod.ToArray());
            }
        }

        public int GetBonusFormula(int casterStats)
        {
           return (Bonus + casterStats) * CastLevel + 1;
        }

        public virtual int CalcDuration(Player p)
        {
            double d = p.Stats.Intelligence % 10 + 1 + p.Stats.Level;
            return int.Parse(Math.Ceiling(d).ToString());
        }
    }
}
