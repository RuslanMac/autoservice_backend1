using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication13
{
    public partial class Driver
    {
        public Driver()
        {
            Orders = new HashSet<Order>();
        }

        public int IdDriver { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
