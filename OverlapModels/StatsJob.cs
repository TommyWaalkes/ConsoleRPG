using RPGConsoleGame.Jobs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.OverlapModels
{
    internal class StatsJob
    {
        [Key]
        public int Id { get; set; }
        public virtual Stat Stats { get; set; }
        public virtual Job Job { get; set; }
    }
}
