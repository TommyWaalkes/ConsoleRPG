using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Skills
{
    public class Effect
    {
        [Key]
        public int Id { get; set; }
        public int Duration { get; set; } = 1;
        [NotMapped]
        public Dictionary<Stat, int> statsToAmount { get; set; } = new Dictionary<Stat, int>();
        public bool Active => Duration > 0;
        //This is to make entity happy
        public Effect() { }

        public Effect(int duration, params KeyValuePair<Stat, int>[] statsToAmount)
        {
            Duration = duration;
            foreach (Stat s in this.statsToAmount.Keys)
            {
                this.statsToAmount.Add(s, this.statsToAmount[s]);
            }
        }

        public virtual void DecrementDuration()
        {
            Duration--;
        }

        public virtual void ApplyEffect(params Player[] targets)
        {
            foreach(Player t in targets)
            {
                foreach(Stat s in statsToAmount.Keys)
                {
                    t.ModStats(s, statsToAmount[s]);
                }
            }
        }

        public virtual void RemoveEffect(params Player[] targets)
        {
            foreach (Player t in targets)
            {
                foreach (Stat s in statsToAmount.Keys)
                {
                    t.ModStats(s, -statsToAmount[s]);
                }
            }
        }

    }
}
