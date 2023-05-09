using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPGConsoleGame
{
    public class Growths
    {
        public int Defense { get; set; } = 0;
        public int Attack { get; set; } = 0;
        public int Damage { get; set; } = 1;
        public int Hp { get; set; } = 1;
        public int Speed { get; set; } = 1;
        public int Intelligence { get; set; } = 0;
        public int Luck { get; set; } = 0;

        public Growths()
        {

        }

        public Growths(int defense, int attack, int damage, int hp, int speed, int intelligence, int luck)
        {
            Defense = defense;
            Attack = attack;
            Damage = damage;
            Hp = hp;
            Speed = speed;
            Intelligence = intelligence;
            Luck = luck;
        }

        public static Growths CombineGrowths(params Growths[] stats)
        {
            Growths output = new Growths();
            foreach (Growths stat in stats)
            {
                output.Attack += stat.Attack;
                output.Defense += stat.Defense;
                output.Speed += stat.Speed;
                output.Luck += stat.Luck;
                output.Damage += stat.Damage;
                output.Intelligence+= stat.Intelligence;
                output.Hp += stat.Hp;
            }

            return output;
        }

        public void PrintGrowths()
        {
            Console.WriteLine("Growths, you get these added to your stats each level");
            Console.WriteLine("Skills and items may increase these");
            Console.WriteLine($"Attack: {Attack}");
            Console.WriteLine($"Defense: {Defense}");
            Console.WriteLine($"Hp: {Hp}");
            Console.WriteLine($"Intelegence: {Intelligence}");
            Console.WriteLine($"Speed: {Speed}");
            Console.WriteLine($"Luck: {Luck}");
            Console.WriteLine();


        }
    }
}
