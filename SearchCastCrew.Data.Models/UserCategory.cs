using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCastCrew.Data.Models
{
    public class UserCategory
    {
        public int UserCategoryId { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
