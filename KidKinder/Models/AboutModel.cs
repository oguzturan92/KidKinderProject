using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidKinder.Models
{
    public class AboutModel
    {
        public About About { get; set; }
        public List<AboutList> AboutLists { get; set; }
        public List<Service> Services { get; set; }
        public List<Teacher> Teachers { get; set; }

    }
}