using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.DataAccess;

public class OfferRepository : IOfferRepository {
    private readonly RockeseatAuctionDbContext _dbContext;
    public OfferRepository(RockeseatAuctionDbContext dbContext) => _dbContext = dbContext;

    public void Add(Offer offer) {
        _dbContext.Offers.Add(offer);
        _dbContext.SaveChanges();
    }
}
