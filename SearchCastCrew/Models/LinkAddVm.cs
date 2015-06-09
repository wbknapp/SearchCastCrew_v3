using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SearchCastCrew.Data.Models;
using System.Web.Mvc;

namespace SearchCastCrew.Models
{
    public class LinkAddVm
    {
        public Link NewLink { get; set; }

        public IEnumerable<SelectListItem> LinkTypeList
        {
            get
            {
                return new List<SelectListItem>
                {
                    new SelectListItem { Text = "Facebook", Value = "Facebook" },
                    new SelectListItem { Text = "Twitter", Value = "Twitter" },
                    new SelectListItem { Text = "Instagram", Value = "Instagram" },
                    new SelectListItem { Text = "LinkedIn", Value = "LinkedIn" },
                    new SelectListItem { Text = "Other", Value = "Other" }
                };
            }
        }
    }
}