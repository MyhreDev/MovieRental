using MovieRental.Data.AuctionHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRental.Repository
{
    public interface IAuctionHouseRepository
    {
        Task<List<Deal>> GetDeals(string serverName);
        Task<List<Server>> GetServers();

    }
}
