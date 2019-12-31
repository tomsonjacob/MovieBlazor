using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlazor.Models
{
    public class ActorCredit
    {
        public string character { get; set; }
        public string original_title { get; set; }
        public int id { get; set; }
        public string poster_path { get; set; }
       
    }
}
