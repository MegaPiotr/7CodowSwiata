﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    public class Cod
    {
        public int Poziom { get; set; }
        public Dictionary<RodzajSurowca, int> Koszt { get; set; }
        public List<Efekt> Efekty { get; set; }
    }
}
