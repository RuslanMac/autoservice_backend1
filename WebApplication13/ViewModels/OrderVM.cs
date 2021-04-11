using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Tables
{
    public class OrderVM
    {
        public List<string> SourceRegions { get; set; }
        public List<string>  DestinationCity { get; set; }



        public IEnumerable<RateVM> Rates { get; set; }

        public IEnumerable<CarsVM> Carsp { get; set; }

        public IEnumerable<RegionVM> Regionsnp { get; set; }


    }
}
