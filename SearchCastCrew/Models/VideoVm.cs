using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchCastCrew.Models
{
    public class VideoVm
    {
        public string UserId { get; set; }
        public int VideoId { get; set; }
        [Display(Name = "Link to Video")]
        public string VideoUrl { get; set; }
        [Display(Name = "Video Description")]
        public string VideoDesc { get; set; }
    }
}