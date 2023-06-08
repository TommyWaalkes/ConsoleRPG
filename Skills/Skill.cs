using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Skills
{
    public abstract class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Stat> StatsUsed = new List<Stat>();
        public int Magnitude { get; set; } = 1;

        public Skill(string Name, string Description) {
            this.Name = Name;
            this.Description = Description;
        }
        public Skill() { }



        public abstract void Effect(Player caster, params Player[] targets);

    }
}
