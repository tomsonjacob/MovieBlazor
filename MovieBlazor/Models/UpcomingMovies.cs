using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlazor.Models
{
    public class UpcomingMovies
    {
        public int id { get; set; }
        public string poster_path { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }

    }
}
