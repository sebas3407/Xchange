using System;
using System.Collections.Generic;

namespace Xchange.Models
{
    public class Rate
    {
        public string currencyName { get; set; }
        public string currencySymbol { get; set; }
        public string id { get; set; }
    }

    public class RootObject
    {
        public List<Rate> Rate { get; set; }
    }
}
