using System;
using System.Collections.Generic;

namespace Web_xemphim.Data
{
    public partial class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        public int DirectorId { get; set; }
        public string? Name { get; set; }
        public string? Detail { get; set; }
        public bool? Checked { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
