using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace FiveNumberSummary
{
    public class Results : ViewModelBase
    {
        public double Min { get; set; }
        public double Q1 { get; set; }
        public double Med { get; set; }
        public double Q3 { get; set; }
        public double Max { get; set; }
    }
}

