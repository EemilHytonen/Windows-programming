using System;
using System.Collections.Generic;

namespace Assignment_4
{
    class FlightPriceComparer : IComparer<Flight>
    {
        public int Compare(Flight x, Flight y)
        {
            return x.Price.CompareTo(y.Price);
        }
        
    }
}
