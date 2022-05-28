using System;
using System.Collections.Generic;

namespace Web_xemphim.Data
{
    public partial class User
    {
        public User()
        {
            UsersMovies = new HashSet<UsersMovie>();
        }

        public int UsersId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public bool? Checked { get; set; }

        public virtual ICollection<UsersMovie> UsersMovies { get; set; }
    }
}
