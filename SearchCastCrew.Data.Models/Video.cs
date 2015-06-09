using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCastCrew.Data.Models
{
    public class Video
    {
        [Key]
        public int VideoId { get; set; }
        [Display(Name = "Video URL")]
        public string VideoUrl { get; set; }
        [Display(Name = "Video Description")]
        public string VideoDesc { get; set; }
        public bool IsDeleted { get; set; }
        // FK to User table
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
