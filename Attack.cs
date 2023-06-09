﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame
{
    public enum DamageType
    {
        Slashing, 
        Blunt, 
        Piercing, 
        Magic, 
        Fire, 
        Ice, 
        Acid, 
        Air
    }
    public class Attack
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DamageType damageType { get; set; }

        public int minDamage { get; set; } = 1;
        public int maxDamage { get; set; } = 3;

        public Attack(string Name, DamageType damageType, int minDamage, int maxDamage)
        {
            this.Name = Name;
            this.damageType = damageType;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
        }

        public Attack() { }

        public static bool IsPhysical(Attack a)
        {
            return a.damageType == DamageType.Blunt || a.damageType == DamageType.Slashing || a.damageType == DamageType.Piercing;
        }

        public static Attack GenerateRandom(int level)
        {
            DamageType[] damageTypes = (DamageType[])Enum.GetValues(typeof(DamageType));
            Random r = new Random();
            int roll = r.Next(0, damageTypes.Length);
            DamageType dt = damageTypes[roll];
            int min = 1 + level * r.Next(1, 5);
            int max = min + level* r.Next(1, 5);
            string name = "";
            switch (dt)
            {
                case DamageType.Blunt:
                    name = "club";
                    break;
                case DamageType.Slashing:
                    name = "sword";
                    break; 
                case DamageType.Piercing:
                    name = "spear";
                    break;
                case DamageType.Fire:
                    name = "fireball";
                    break;
                case DamageType.Ice:
                    name = "cold beam";
                    break;
                case DamageType.Air:
                    name = "lighting Bolt";
                    break;
                case DamageType.Acid:
                    name= "Acid Arrow";
                    break;
                case DamageType.Magic:
                    name = "Magic Bolt";
                    break;
            }
            name += " +" + level;
            Attack a = new Attack(name, dt, min, max);
            return a; 
            
        }


    }
}
