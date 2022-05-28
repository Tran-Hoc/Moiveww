using System;
using System.Collections.Generic;

namespace Web_xemphim.Data
{
    public partial class NationalMovie
    {
        public int NationalsId { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public virtual National Nationals { get; set; } = null!;
    }
}
