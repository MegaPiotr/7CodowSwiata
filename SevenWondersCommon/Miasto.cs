﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenWondersCommon
{
    public class Miasto
    {
        public string Nazwa { get; set; }
        public List<Cod> Coda { get; set; }
        public List<Efekt> Efekty { get; set; }
        public string Obrazek { get; set; }
    }
}
