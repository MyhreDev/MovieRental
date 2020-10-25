using MovieRental.Data.AuctionHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRental.Repository
{
    public class AutionHouseRepository : IAuctionHouseRepository
    {
        public Task<List<Deal>> GetDeals(string serverName)
        {
            return Task.FromResult(new List<Deal>());
        }

        public Task<List<Server>> GetServers()
        {
            return Task.FromResult(new List<Server>());
        }
    }
}
