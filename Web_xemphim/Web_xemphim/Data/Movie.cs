using System;
using System.Collections.Generic;

namespace Web_xemphim.Data
{
    public partial class Movie
    {
        public Movie()
        {
            KeywordMovies = new HashSet<KeywordMovie>();
            UsersMovies = new HashSet<UsersMovie>();
        }

        public int MovieId { get; set; }
        public int DirectorId { get; set; }
        public string? MovieName { get; set; }
        public string? Detail { get; set; }
        public double? MovieLength { get; set; }
        public string? MoviePath { get; set; }
        public bool? Checked { get; set; }
        public string? ImgPath { get; set; }
        public int? ReleaseYearId { get; set; }
        public int? KeywordId { get; set; }
        public int? Languages { get; set; }
        public int? Views { get; set; }
        public string? TrailerPath { get; set; }
        public int? Typemovie { get; set; }

        public virtual Director Director { get; set; } = null!;
        public virtual ReleaseYear? ReleaseYear { get; set; }
        public virtual ICollection<KeywordMovie> KeywordMovies { get; set; }
        public virtual ICollection<UsersMovie> UsersMovies { get; set; }
    }
}
