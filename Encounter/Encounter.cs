using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Encounter
{
    internal class Encounter
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public List<Choice> Choices { get; set; } = new List<Choice>();

        public Encounter(string Name, string Message, Player p, params Choice[] Choices) { 
            this.Name= Name;
            this.Message= Message;
            this.Choices = Choices.ToList();
            foreach(Choice c in Choices)
            {
                c.SetCanPick(p);
            }
        }
    }
}
