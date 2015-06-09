using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCastCrew.Data.Models
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }
        public string Name { get; set; }
    }
}
