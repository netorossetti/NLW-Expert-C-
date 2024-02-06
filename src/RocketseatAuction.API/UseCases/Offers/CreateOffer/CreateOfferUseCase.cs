using RocketseatAuction.API.Communication.Request;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase {
    private readonly LoggedUser _loogedUser;
    public CreateOfferUseCase(LoggedUser loogedUser) => _loogedUser = loogedUser;

    public int Execute(int itemId, RequestCreateOfferJson request) {
        var repository = new RockeseatAuctionDbContext();
        var user = _loogedUser.User();

        var offer = new Offer {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id
        };

        repository.Offers.Add(offer);
        repository.SaveChanges();

        return offer.Id;
    }
}
