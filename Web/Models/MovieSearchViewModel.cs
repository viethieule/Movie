using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class MovieSearchViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleLong { get; set; }
        public string ImageSmallUrl { get; set; }
        public string ImageMediumUrl { get; set; }
        public string Hash { get; set; }
    }
}
