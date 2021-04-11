using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication13
{
    public partial class License
    {
        public License()
        {
            Cars = new HashSet<Car>();
        }

        public int IdLicense { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
