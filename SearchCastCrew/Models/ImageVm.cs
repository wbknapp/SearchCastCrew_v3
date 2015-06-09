using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchCastCrew.Models
{
    public class ImageVm
    {
        public int ImageId { get; set; }
        public string ImgUrl { get; set; }
        public string ImgDesc { get; set; }
        public bool IsProfile { get; set; }
    }
}