using RocketseatAuction.API.Communication.Request;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Services;

namespace RocketseatAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase {
    private readonly ILoggedUser _loogedUser;
    private readonly IOfferRepository _offerRepository;
    public CreateOfferUseCase(ILoggedUser loogedUser, IOfferRepository offerRepository) {  
        _loogedUser = loogedUser;
        _offerRepository = offerRepository;
    }

    public int Execute(int itemId, RequestCreateOfferJson request) {
        var user = _loogedUser.User();

        var offer = new Offer {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = user.Id
        };

        _offerRepository.Add(offer);

        return offer.Id;
    }
}
