﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fifa
{
    public class Stat
    {
        public int Year { get; set; }
        public string[] Hosts { get; set; }

        public string Team1 { get; set; }
        public string Score12 { get; set; }
        public string Team2 { get; set; }

        public string Team3 { get; set; }
        public string Score34 { get; set; }
        public string Team4 { get; set; }
    }
}
