using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlazor.Models
{
    public class Credits
    {
        public int id { get; set; }
        public List<Cast> cast { get; set; }
       
        // public List<Crew> crew { get; set; }
    }
}