using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication13
{
    public partial class Region
    {
        public Region()
        {
            RouteIdRegionDNavigations = new HashSet<Route>();
            RouteIdRegionNavigations = new HashSet<Route>();
        }

        public int IdRegion { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Route> RouteIdRegionDNavigations { get; set; }
        public virtual ICollection<Route> RouteIdRegionNavigations { get; set; }
    }
}
