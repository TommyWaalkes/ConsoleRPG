using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Skills
{
    public abstract class Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Stat> StatsUsed = new List<Stat>();
        public int Magnitude { get; set; } = 1;

        public Skill(string Name, string Description) {
            this.Name = Name;
            this.Description = Description;
        }



        public abstract void Effect(Player caster, params Player[] targets);

    }
}
