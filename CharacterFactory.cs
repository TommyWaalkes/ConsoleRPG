﻿using RPGConsoleGame.Jobs;
using RPGConsoleGame.Races;
using RPGConsoleGame.SaveGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame
{
    internal class CharacterFactory
    {
        public List<Race> Races = new List<Race>();
        public List<Job> Jobs = new List<Job>();

        public CharacterFactory()
        {
            Jobs.Add(new Fighter());
            Jobs.Add(new Mage());
            Jobs.Add(new Barbarian());
            Jobs.Add(new Cleric());
            Races.Add(new Human());

        }

        public Player DecidePlayerCreation(int level)
        {
            Console.WriteLine("Would you like load a saved character or make a new one or make a random characer? load/new/random");
            string response = Console.ReadLine().ToLower();
            Player p; 
            if(response == "load")
            {
                p = LoadPlayer();
            }
            else if(response == "new")
            {
                p =  CreateByHand(level);
                List<Attack> startingAttacks = new List<Attack>();
                startingAttacks.Add(Attack.GenerateRandom(level));
                startingAttacks.Add(Attack.GenerateRandom(level));
                startingAttacks.Add(Attack.GenerateRandom(level));
                Console.WriteLine("Select a random starting weapon");
                for (int i = 0; i < startingAttacks.Count; i++)
                {
                    Attack attack = startingAttacks[i];
                    Console.WriteLine($"{i}: Damage:{attack.minDamage}-{attack.maxDamage}, Type:{attack.damageType} ");
                }

                int pick = int.Parse(Console.ReadLine());

                Attack picked = startingAttacks[pick];
                p.AddAttack(picked);
            }
            else if(response == "random")
            {
                p = GenerateRandom(level);
                p.AddAttack(Attack.GenerateRandom(level));
            }
            else
            {
                Console.WriteLine("I'm sorry I didn't understand lets try again");
                p = DecidePlayerCreation(level);
            }


            return p;
        }

        public Player LoadPlayer()
        {
            string[] names = SaveFunctions.GetPlayerNames();
            for(int i = 0; i < names.Length; i++)
            {
                string name = names[i];
                Console.WriteLine(i +": " + name);
            }
            Console.WriteLine("Which player would you like to load?");
            int pick = int.Parse(Console.ReadLine());

            return SaveFunctions.LoadPlayer(names[pick]);
        }
        public  Player CreateByHand(int level)
        {
            
            Console.WriteLine("Please select a race you'd wish to use");
            PrintRaces();
            int pick = int.Parse(Console.ReadLine());
            Race r = Races[pick];

            Console.WriteLine();
            Console.WriteLine("Next Select a job you'd wish to use");
            PrintJobs(); 
            int pick2 = int.Parse(Console.ReadLine());
            Job j = Jobs[pick2];
            Console.WriteLine("Lastly name your character:");
            string name = Console.ReadLine();

            Player p = new Player(j, r, name);
            p.Stats.Level = level;
           
            p.PrintCharacterSheet();
            Console.WriteLine("Go with this character? y/n");
            string response = "";
            while(response.Trim().ToLower() != "y" || response != "n")
            {
                response = Console.ReadLine();
                if(response == "y" || response =="n")
                {
                    break;
                }
            }

            if(response == "y" ) {
                Console.WriteLine("Saving new player");
                SaveFunctions.SavePlayer(p);
                Console.WriteLine(p.Name + " saved sucessfully");
                return p;

            }
            else
            {
                return CreateByHand(1);
            }

           
        }

        public  Player GenerateRandom(int level)
        {
            Random r = new Random(); 
            int jPick = r.Next(0, Jobs.Count);
            int rPick = r.Next(0, Races.Count);

            Job j = Jobs[rPick];
            Race ra = Races[rPick];
            Player player = new Player(j, ra, "Smeef");
            return player;
        }

        public  void PrintRaces()
        {
            for(int i = 0; i < Races.Count; i++)
            {
                Console.WriteLine($"{i}:{Races[i].Name}");
            }
        }

        public void PrintJobs()
        {
            for (int i = 0; i < Jobs.Count; i++)
            {
                Console.WriteLine($"{i}:{Jobs[i].Name}");
            }
        }
    }
}
