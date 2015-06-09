using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchCastCrew.Models
{
    public class ImageProfileVm
    {
        public string UserId { get; set; }
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsProfile { get; set; }
    }
}