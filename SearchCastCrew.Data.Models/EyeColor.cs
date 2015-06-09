﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchCastCrew.Data.Models
{
    public class EyeColor
    {
        [Key]
        public int EyeColorId { get; set; }
        public string Color { get; set; }
    }
}
