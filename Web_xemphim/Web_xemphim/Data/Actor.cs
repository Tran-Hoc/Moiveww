using System;
using System.Collections.Generic;

namespace Web_xemphim.Data
{
    public partial class Actor
    {
        public int ActorId { get; set; }
        public string? Name { get; set; }
        public string? Detail { get; set; }
        public bool? Checked { get; set; }
    }
}
