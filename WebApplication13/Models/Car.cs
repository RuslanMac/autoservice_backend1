using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication13
{
    public partial class Car
    {
        public Car()
        {
            Orders = new HashSet<Order>();
        }

        public int IdCar { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public long Capacity { get; set; }
        public int IdLicense { get; set; }

        public virtual License IdLicenseNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; } 
    }
}
