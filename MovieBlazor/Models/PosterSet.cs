
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlazor.Models
{
    public class PosterSet {
        public List<Poster> results { get; set; }
        public string page { get; set; }
        public string total_results { get; set; }
        public string total_pages { get; set; }
    }
}