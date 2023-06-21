using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.Jobs
{
    internal class JobLevelUp
    {
        public Job Job { get; set; }
        public int Level { get; set; } = 1; 

        public JobLevelUp(Job j, int Level) { 
            this.Job = j;
            this.Level  = Level;
        }
    }
}
