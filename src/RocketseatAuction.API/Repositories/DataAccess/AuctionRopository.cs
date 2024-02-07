using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAccess;

public class AuctionRopository: IAuctionRepository {
    private readonly RockeseatAuctionDbContext _dbContext;
    public AuctionRopository(RockeseatAuctionDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent() {
        var today = DateTime.Now;

        return _dbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => auction.Starts <= today && auction.Ends >= today);
    }
}
