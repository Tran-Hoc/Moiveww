using System;
using System.Collections.Generic;

namespace Web_xemphim.Data
{
    public partial class KeywordMovie
    {
        public int KeywordId { get; set; }
        public int MovieId { get; set; }
        public int Id { get; set; }

        public virtual Keyword Keyword { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
