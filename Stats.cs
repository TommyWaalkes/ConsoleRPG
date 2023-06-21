using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame
{
    public enum Stat
    {
        Attack,
        Damage,
        Hp, 
        Defense,
        Speed,
        Intelligence, 
        Luck
    }
    public class Stats
    {
        [Key]
        public int Id { get; set; }
        public int Defense { get; set; } = 0; 
        public int Attack { get; set; } = 0;
        public int Damage { get; set; } = 1;
        public int HpMax { get; set; } = 1;
        public int HpCurrent { get; set; } = 1;
        public int Speed { get; set; } = 1;
        public int SpeedDice => (Level + Speed + Luck/2) / DiceGrowth;
        public int DiceGrowth = 4;
        public int Intelligence { get; set; } = 0;
        public int Luck { get; set; } = 0;
        public int Level { get; set; } = 1;
        public int Xp { get; set; } = 0;
        public int XpNext => Level * 100;
        public bool _canLevel => Xp >= XpNext;

        public Stats() {
            HpCurrent = HpMax;
        }

        public Stats(int defense, int attack, int damage, int hpMax, int hpCurrent, int speed, int intelligence, int luck, int level, int xp)
        {
            Defense = defense;
            Attack = attack;
            Damage = damage;
            HpMax = hpMax;
            HpCurrent = hpCurrent;
            Speed = speed;
            Intelligence = intelligence;
            Luck = luck;
            Level = level;
            Xp = xp;
        }

        public void gainXp(int amount, Growths g)
        {
            Xp += amount;
            if (Xp >= XpNext)
            {
                LevelUp(g);
            }
        }

        public void LevelUp(Growths g)
        {
            while (_canLevel)
            {
                Level++;
                HpMax = g.Hp * Level;
                HpCurrent = HpMax;

                Attack += g.Attack;
                Defense += g.Defense;
                Speed += g.Speed;
                Luck += g.Luck;
                Intelligence+= g.Intelligence;
            }
        }

        public static Stats CombineStats(params Stats[] stats)
        {
            Stats output = new Stats();
            foreach (Stats stat in stats)
            {
                output.Attack += stat.Attack;
                output.Defense += stat.Defense;
                output.Speed += stat.Speed;
                output.Luck += stat.Luck; 
                output.Damage += stat.Damage;
                output.HpMax += stat.HpMax;
                output.HpCurrent = output.HpMax;
                output.Intelligence+= stat.Intelligence;
            }

            return output;
        }

        public void PrintStats()
        {
            Console.WriteLine("Stats:");
            Console.WriteLine($"Attack: {Attack}");
            Console.WriteLine($"Defense: {Defense}");
            Console.WriteLine($"Hp: {HpCurrent}/{HpMax}");
            Console.WriteLine($"Intelegence: {Intelligence}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Speed Dice: {SpeedDice}");
            Console.WriteLine($"Luck: {Luck}");
            Console.WriteLine();
            Console.WriteLine($"Experience: {Xp}");
            Console.WriteLine($"Next Level: {XpNext}");



        }
    }
}
