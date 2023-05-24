using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGConsoleGame.Jobs;
using RPGConsoleGame.Races;
using RPGConsoleGame.Skills;

namespace RPGConsoleGame
{
    public class Player
    {
        public string Name { get; set; }
        public Race Race { get; set; }
        public Job Job { get; set; }
        public Stats Stats { get; set; }
        public Growths Growths { get; set; }
        public List<Attack> Attacks { get; set; } = new List<Attack>();
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public List<Effect> Effects { get; set; } = new List<Effect>();
        public int Gold { get; set; } = 100;
        public bool IsAlive => Stats.HpCurrent > 0;
        public Player(Job job, Race Race, string name)
        {
            this.Job = job;
            this.Race = Race;
            this.Stats = Stats.CombineStats(job.Stats, Race.Stats);
            this.Growths = Growths.CombineGrowths(job.Growths, Race.Growths);
            Attacks.AddRange(job.Attacks);
            Name = name;
        }

        public void AddAttack(Attack newArrack)
        {
            Attacks.Add(newArrack);
        }

        public int RollDamage(Attack a)
        {
            Random r = new Random();
            int damage = r.Next(a.minDamage, a.maxDamage + 1) +1;
            if (Attack.IsPhysical(a))
            {
                damage += Stats.Attack;
            }
            else
            {
                damage += Stats.Intelligence;
            }

            return damage;
        }

        public void TakeDamage(int damage)
        {
            damage -= Stats.Defense;
            if (damage < 0)
            {
                damage = 1;
            }
            Stats.HpCurrent -= damage;
        }

        public void AddEffect(Effect e)
        {
            e.ApplyEffect(this);
            Effects.Add(e);
        }

        public void RemoveEffect(Effect e)
        {
            e.RemoveEffect(this);
            Effects.Remove(e);
        }
        public void RemoveEffect(int index)
        {
            Effect e = Effects[index];
            e.RemoveEffect(this);
            Effects.RemoveAt(index);
        }

        public void EndTurn()
        {
            for(int i = 0; i < Effects.Count; i++)
            {
                Effect e = Effects[i];
                e.DecrementDuration(); 
                if(e.Duration <= 0) {
                    RemoveEffect(i);
                }
            }
        }

        public void ModStats(Stat s, int amount)
        {
            switch (s)
            {
                case Stat.Attack: 
                    Stats.Attack += amount;
                    break;
                case Stat.Defense:
                    Stats.Defense += amount; 
                    break;
                case Stat.Intelligence:
                    Stats.Intelligence += amount;
                    break;
                case Stat.
                    Speed: Stats.Speed += amount; 
                    break;
                case Stat.Luck: 
                    Stats.Luck += amount; 
                    break;
                case Stat.Hp: 
                    Stats.HpCurrent+= amount;
                    Stats.HpMax += amount;
                    break;

            }
        }

        public void DecrementDuration()
        {
            foreach (Effect e in Effects)
            {

            }
        }

        public Attack SelectAttack(int index)
        {
            return Attacks[index];
        }

        public void PrintAttacks()
        {
            int i = 0; 
            for (; i < Attacks.Count; i++)
            {
                Attack a = Attacks[i];
                if (Attack.IsPhysical(a))
                {
                    Console.WriteLine($"{i}){a.Name} {a.damageType} : {a.minDamage+1}-{a.maxDamage + 1} + {Stats.Attack}");
                }
                else
                {
                    Console.WriteLine($"{i}){a.Name} {a.damageType} : {a.minDamage+1}-{a.maxDamage +1} + {Stats.Intelligence}");
                }
            }
        }

        public void PrintSkills()
        {
            for (int i = 0; i < Skills.Count; i++)
            {
                Skill s = Skills[i];
                Console.WriteLine($"{i}:{s.Name}");
                i++;
            }
        }

        public void PrintCharacterSheet()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Race: "+Race.Name);
            Console.WriteLine("Class: "+Job.Name);

            Stats.PrintStats();
            Growths.PrintGrowths();
        }
    }
}
