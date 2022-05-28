using System;
using System.Collections.Generic;

namespace Web_xemphim.Data
{
    public partial class MovieGenre
    {
        public int MovieId { get; set; }
        public int GenresId { get; set; }

        public virtual Genre Genres { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
