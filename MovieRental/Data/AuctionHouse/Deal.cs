using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRental.Data.AuctionHouse
{
    public class Deal
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string UniqueName { get; set; }
        public string Icon { get; set; }
        public int MarketValue { get; set; }
        public int MinBuyout { get; set; }
        public int DealDiff { get; set; }
        public int DealPercentage { get; set; }

    }
}
