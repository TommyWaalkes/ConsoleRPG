﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGConsoleGame.Jobs;
using RPGConsoleGame.Races;

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
        public int Gold { get; set; } = 100;
        public bool IsAlive => Stats.HpCurrent > 0;
        public Player(Job job, Race Race, string name)
        {
            this.Job = job;
            this.Race = Race;
            this.Stats = Stats.CombineStats(job.Stats, Race.Stats);
            this.Growths = Growths.CombineGrowths(job.Growths, Race.Growths);
            Attacks.Add(new Attack("fist", DamageType.Blunt, 1, 3));
            Name = name;
        }

        public void AddAttack(Attack newArrack)
        {
            Attacks.Add(newArrack);
        }

        public int RollDamage(Attack a)
        {
            Random r = new Random();
            int damage = r.Next(a.minDamage, a.maxDamage + 1);
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
            Stats.HpCurrent -= damage;
        }

        public Attack SelectAttack(int index)
        {
            return Attacks[index];
        }

        public void PrintAttacks()
        {
            for (int i = 0; i < Attacks.Count; i++)
            {
                Attack a = Attacks[i];
                if (Attack.IsPhysical(a))
                {
                    Console.WriteLine($"{i}){a.Name} {a.damageType} : {a.minDamage}-{a.maxDamage} + {Stats.Attack}");
                }
                else
                {
                    Console.WriteLine($"{i}){a.Name} {a.damageType} : {a.minDamage}-{a.maxDamage} + {Stats.Intelligence}");
                }
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