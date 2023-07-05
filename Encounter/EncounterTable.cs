using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Encounter
{
    internal class EncounterTable
    {
        public List<Encounter> Encounters = new List<Encounter>();

        public EncounterTable()
        {
            //Encounters.Add(new Encounter("Little Timmy is in the well", 
            //    "Oh no little timmy has fallen down the well, how do you try to rescue him?", 
            //    new Choice("Pull him up" ),
            //    ));
        }
    }
}
