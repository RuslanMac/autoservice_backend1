using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication13
{
    public partial class Route
    {
        public Route()
        {
            Orders = new HashSet<Order>();
        }

        public int IdRoute { get; set; }
        public decimal Distance { get; set; }
        public int IdRegion { get; set; }
        public int IdRegionD { get; set; }

        public virtual Region IdRegionDNavigation { get; set; }
        public virtual Region IdRegionNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
