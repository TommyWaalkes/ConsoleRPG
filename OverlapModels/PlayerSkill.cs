using RPGConsoleGame.Skills;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGConsoleGame.OverlapModels
{
    internal class PlayerSkill
    {
        [Key]
        public int Id { get; set; }
        public virtual Player Player { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
