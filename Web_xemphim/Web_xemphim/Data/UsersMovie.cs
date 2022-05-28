using System;
using System.Collections.Generic;

namespace Web_xemphim.Data
{
    public partial class UsersMovie
    {
        public int MovieId { get; set; }
        public int UsersId { get; set; }
        public string? Commment { get; set; }
        public int? Vote { get; set; }
        public double? Viewingtime { get; set; }
        public int Id { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public virtual User Users { get; set; } = null!;
    }
}
