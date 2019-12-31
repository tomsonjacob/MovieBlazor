using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlazor.Models
{
    public class LatestMovie
    {
        public int id { get; set; }
        public string backdrop_path { get; set; }
        public string original_title { get; set; }
    }
}
