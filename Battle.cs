using RPGConsoleGame.SaveGame;
using RPGConsoleGame.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame
{
    public enum BattleState
    {
        None,
        Win, 
        Loss, 
        Draw
    }
    internal class Battle
    {
        public Player Player { get; set; }
        public Player Opponent { get; set; }


        public Battle (Player player, Player opponent)
        {
            Player = player;
            Opponent = opponent;
          
        }

        public Player DetermineFirst()
        {
            Random r = new Random();
            int playerRoll = 0; 
            for(int i = 0; i < Player.Stats.SpeedDice; i++)
            {
                playerRoll += r.Next(1, 21) + Player.Stats.Speed;
            }

            int opponentRoll = 0;
            for (int i = 0; i < Opponent.Stats.SpeedDice; i++)
            {
                opponentRoll += r.Next(1, 21) + Opponent.Stats.Speed;
            }
            Console.WriteLine($"Player Roll: {playerRoll}");
            Console.WriteLine($"Opponent Roll: {opponentRoll}");
            //Player wins ties 
            if(playerRoll>= opponentRoll)
            {
                Console.WriteLine("Player goes first!");
                return Player;
            }
            else
            {
                Console.WriteLine("Opponent goes first!");
                return Opponent;
            }
        }

        public string SelectSkillOrAttack()
        {
            Console.WriteLine("Would you like to (1) attack or (2) use a skill?");
            string input = Console.ReadLine().ToLower();
            if(input == "1" || input == "attack")
            {
                return "attack";
            }
            else if(input == "2"|| input == "skill")
            {
                return "skill";
            }
            else
            {
                Console.WriteLine("Im sorry I didnt understand lets try again");
                return SelectSkillOrAttack();
            }
        }

        public Attack PlayerPickAttack()
        {
            Player.PrintAttacks();

            Console.WriteLine("Please select an attack or skill: ");
            int input = int.Parse(Console.ReadLine());
            if (input >= 0 && input < Player.Attacks.Count) { 
                return Player.Attacks[input];
            }
            else
            {
                Console.WriteLine("Sorry that was not a valid input, please try again");
                return PlayerPickAttack();
            }
        
        }

        public Skill PlayerPickSkill()
        {
            
            Console.WriteLine("Please select a skill: ");
            int input = int.Parse(Console.ReadLine()); 
            if(input >=0 && input <Player.Skills.Count)
            {
                return Player.Skills[input];
            }
            else
            {
                Console.WriteLine("Invalid input lets try again");
                return PlayerPickSkill();
            }
        }

        public Attack RandomPickAttack()
        {
            Random r = new Random();
            int pick = r.Next(0, Opponent.Attacks.Count);
            Attack a = Opponent.Attacks[pick];
            return a; 
        }

        public BattleState Round()
        {
            Player first = DetermineFirst();
            Player second;
            Console.WriteLine("Your HP: " + Player.Stats.HpCurrent);
            Console.WriteLine("Enemy HP: " + Opponent.Stats.HpCurrent);
            if (Player.IsAlive && Opponent.IsAlive)
            {

                if (first == Player)
                {
                    second = Opponent;
                    Attack a = PlayerPickAttack();
                    int damage = first.RollDamage(a);
                    damage = first.ApplyCrits(damage);
                    if (!second.Dodge())
                    {
                        second.TakeDamage(damage);
                    }
                    else
                    {
                        Console.WriteLine(second.Name +" dodged");
                    }

                    Attack b = RandomPickAttack();
                    int ODamage = second.RollDamage(b);
                    first.TakeDamage(ODamage);

                }
                else
                {
                    second = Player;
                    Attack b = RandomPickAttack();
                    int ODamage = second.RollDamage(b);
                    first.TakeDamage(ODamage);

                    Attack a = PlayerPickAttack();
                    int damage = first.RollDamage(a);
                    second.TakeDamage(damage);

                }

                
            }
            if (Player.IsAlive && Opponent.IsAlive)
            {
                return Round();
            }
            else if(!Player.IsAlive && !Opponent.IsAlive)
            {
                return BattleState.Draw;
            }
            else if(Player.IsAlive && !Opponent.IsAlive)
            {
                Console.WriteLine("You heal up to max and gain xp!");
                int xpGain = Opponent.Stats.Level * Opponent.Stats.HpMax + 1;
                Player.Stats.gainXp(xpGain, Player.Growths);
                Player.Stats.HpCurrent = Player.Stats.HpMax;
                return BattleState.Win;
            }
            else if(Opponent.IsAlive && !Player.IsAlive) { }
            {
                return BattleState.Loss;
            }
            
        }
    }
}
