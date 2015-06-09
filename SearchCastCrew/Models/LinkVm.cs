using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchCastCrew.Models
{
    public class LinkVm
    {
        public int LinkId { get; set; }
        public string LinkUrl { get; set; }
        public string LinkType { get; set; }
        public string LinkDesc { get; set; }
    }
}