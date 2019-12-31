using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBlazor.Models
{
    public class Cast
    {
        public int id { get; set; }
        public int cast_id { get; set; }
        public string character { get; set; }
        public string profile_path { get; set; }
        public string name { get; set; }
    }
}