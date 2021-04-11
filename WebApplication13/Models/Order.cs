using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication13
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Cost { get; set; }
        public long Capacity { get; set; }
        public int IdCar { get; set; }
        public int IdTariff { get; set; }
        public int IdDriver { get; set; }
        public int IdRoute { get; set; }
        public int IdClient { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public virtual Car IdCarNavigation { get; set; }
        public virtual Client IdClientNavigation { get; set; }
        public virtual Driver IdDriverNavigation { get; set; }
        public virtual Route IdRouteNavigation { get; set; }
        public virtual Rate IdTariffNavigation { get; set; }
    }
}
