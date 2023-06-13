using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RPGConsoleGame.SaveGame
{
    internal class SaveFunctions
    {
        public static void SavePlayer(Player p)
        {
            string json = JsonSerializer.Serialize(p);
            Console.WriteLine(json);
            File.WriteAllText(p.Name+".json", json);
        }

        public static Player LoadPlayer(string name)
        {
            string json = File.ReadAllText(name);
            Player output = JsonSerializer.Deserialize<Player>(json);
            output.PrintCharacterSheet();
            Console.WriteLine("Use this player? y/n");
            string response = Console.ReadLine();
            if (response == "y")
            {
                return output;
            }
            else
            {
                return LoadPlayer(name);
            }
        }

        public static string[] GetPlayerNames()
        {
            string filePath = "C: \\Users\\thoma\\Desktop\\RPG Console Game\\ConsoleRPG\\bin\\Debug\\net6.0\\";
            string[] filePaths = Directory.GetFiles(Directory.GetCurrentDirectory()+"\\characters");
            string[] output = filePaths.Where(p => p.EndsWith(".json")).ToArray();
            return output;
        }
    }
}
