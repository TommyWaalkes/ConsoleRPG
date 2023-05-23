﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Skills
{
    public abstract class Skill
    {
        string Name;
        string Description;
        public List<Stat> StatsUsed = new List<Stat>();
        public int Magnitude { get; set; } = 1;

        public Skill(string Name, string Description) { 
        
        }



        public abstract void Effect(Player caster, params Player[] targets);

    }
}
