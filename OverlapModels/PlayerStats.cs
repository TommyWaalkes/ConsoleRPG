using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.OverlapModels
{
    internal class PlayerStats
    {
        [Key]
        int Id { get; set; }
        public Stat Stats { get; set; }
        public Player Player { get; set; }
    }
}
