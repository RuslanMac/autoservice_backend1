using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication13
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public int IdClient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public long Telephone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
