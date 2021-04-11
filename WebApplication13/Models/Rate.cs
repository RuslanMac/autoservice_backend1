using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication13
{
    public partial class Rate
    {
        public Rate()
        {
            Orders = new HashSet<Order>();
        }

        public int IdRate { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public string name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
