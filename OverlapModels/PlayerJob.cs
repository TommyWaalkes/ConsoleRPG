using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGConsoleGame.Jobs;


namespace RPGConsoleGame.OverlapModels
{
    internal class PlayerJob
    {
        [Key]
        public int Id { get; set; }
        public virtual Player Player { get; set; }
        public virtual Job Job { get; set; } 
    }
}
