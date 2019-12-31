
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlazor.Models
{
    public class Poster
    {
        public int id { get; set; }
        public string adult { get; set; }
        public string popularity { get; set; }
        public string original_language { get; set; }
        public string title { get; set; }
        public List<int> genre_ids { get; set; }
        public string vote_average { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public string poster_path { get; set; }
        public string backdrop_path { get; set; }
    }
}