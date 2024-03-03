using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidKinder.Entities
{
    public class Gallery
    {
        public int GalleryId { get; set; }
        public string GalleryUrl { get; set; }
        public int GalleryRow { get; set; }
        public bool GalleryApproval { get; set; }
    }
}