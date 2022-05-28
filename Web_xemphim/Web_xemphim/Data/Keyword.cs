using System;
using System.Collections.Generic;

namespace Web_xemphim.Data
{
    public partial class Keyword
    {
        public Keyword()
        {
            KeywordMovies = new HashSet<KeywordMovie>();
        }

        public int KeywordId { get; set; }
        public string? Word { get; set; }

        public virtual ICollection<KeywordMovie> KeywordMovies { get; set; }
    }
}
