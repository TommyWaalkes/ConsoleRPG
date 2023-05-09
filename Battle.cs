﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame
{
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

        public Attack PlayerPickAttack()
        {
            Player.PrintAttacks();
            Console.WriteLine("Please select an attack: ");
            int input = int.Parse(Console.ReadLine());
            Attack a = Player.Attacks[input];
            return a; 
        }

        public Attack RandomPickAttack()
        {
            Random r = new Random();
            int pick = r.Next(0, Opponent.Attacks.Count);
            Attack a = Opponent.Attacks[pick];
            return a; 
        }

        public void Round()
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
                    second.TakeDamage(damage);

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

                Round();
            }
            else if(!Player.IsAlive && !Opponent.IsAlive)
            {
                Console.WriteLine("Draw both are dead!");
            }
            else if(Player.IsAlive && !Opponent.IsAlive)
            {
                Console.WriteLine("You Win!");
                Console.WriteLine("You heal up to max and gain xp!");
                int xpGain = Opponent.Stats.Level * Opponent.Stats.HpMax + 1;
                Player.Stats.gainXp(xpGain, Player.Growths);
                Player.Stats.HpCurrent = Player.Stats.HpMax;
            }
            else if(Opponent.IsAlive && !Player.IsAlive) { }
            {
                Console.WriteLine("Your Opponent Wins!");
            }
            
        }
    }
}