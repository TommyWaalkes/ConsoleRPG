using System;
using System.Collections.Generic;
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
    internal class Attack
    {
        public string Name { get; set; }
        public DamageType damageType { get; set; }

        public int minDamage { get; set; } = 1;
        public int maxDamage { get; set; } = 3;

        public Attack(String Name, DamageType damageType, int minDamage, int maxDamage)
        {
            this.Name = Name;
            this.damageType = damageType;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
        }

        public static bool IsPhysical(Attack a)
        {
            return a.damageType == DamageType.Blunt || a.damageType == DamageType.Slashing || a.damageType == DamageType.Piercing;
        }
    }
}
