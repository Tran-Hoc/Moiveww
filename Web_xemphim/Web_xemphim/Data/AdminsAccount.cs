using System;
using System.Collections.Generic;

namespace Web_xemphim.Data
{
    public partial class AdminsAccount
    {
        public int AdminId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public bool? Checked { get; set; }
    }
}
