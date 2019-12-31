using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlazor.Models
{
    public class Movie
    {
        public int id { get; set; }
        public int budget { get; set; }
        public string imdb_id { get; set; }
        public  DateTime release_date { get; set; }
        public string title { get; set; }
        public string poster_path { get; set; }
        public string overview { get; set; }
    }
}