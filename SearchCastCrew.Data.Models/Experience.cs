using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCastCrew.Data.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        [Display(Name = "Work History Entry")]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        // FK to User table
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
