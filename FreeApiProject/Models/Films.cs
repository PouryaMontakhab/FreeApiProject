using System.Collections.Generic;

namespace FreeApiProject.Models
{
    public class Films
    {
        public int Count { get; set; }
        public int? Next { get; set; }
        public int? Previous { get; set; }
        public List<Film> Results { get; set; }
    }
}
