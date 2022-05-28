using System;
using System.Collections.Generic;

namespace Web_xemphim.Data
{
    public partial class ReleaseYear
    {
        public ReleaseYear()
        {
            Movies = new HashSet<Movie>();
        }

        public int ReleaseYearId { get; set; }
        public DateTime? YearRelease { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
