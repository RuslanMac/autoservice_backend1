﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication13.Tables
{
    public class RegionVM
    {
        public string Name { get; set; }

        public int Value { get; set; }
        public List<Region> RouteIdRegionDNavigations { get; set; } 
    }
}
