using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCastCrew.Data.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        [Display(Name = "Link URL")]
        public string LinkUrl { get; set; }
        [Display(Name = "Link Type")]
        public string LinkType { get; set; }
        [Display(Name = "Link Description")]
        public string LinkDesc { get; set; }
        public bool IsDeleted { get; set; }
        // FK to User table
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
