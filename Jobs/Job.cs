using RPGConsoleGame.Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Jobs
{
    public class Job    
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public Stats Stats { get; set; }
        public Growths Growths { get; set; }
        [NotMapped]
        public List<Attack> Attacks { get; set; } = new List<Attack>();
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public Job(string name, string description)
        {
            Description = description;
            Name = name;
        }
        public Job() { }


        public void SetStats(int defense, int attack, int damage, int hpMax, int hpCurrent, int speed, int intelligence, int luck)
        {
            Stats = new Stats(defense, attack, damage, hpMax, hpCurrent, speed, intelligence, luck, 1, 0);
        }

        public void SetGrowths(int defense, int attack, int damage, int hp, int speed, int intelligence, int luck)
        {
            Growths = new Growths(defense, attack, damage, hp, speed, intelligence, luck);
        }

        public virtual void ApplyLevelUp(Player p, int level)
        {
        }

        public string GetUserInput(string message, List<string> allowedResponses)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();

            if (allowedResponses.Contains(input))
            {
                return input;
            }
            else
            {
                return GetUserInput(message, allowedResponses);
            }
        }
    }


}
