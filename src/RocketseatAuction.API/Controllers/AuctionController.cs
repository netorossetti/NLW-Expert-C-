using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

namespace RocketseatAuction.API.Controllers;

public class AuctionController : RocketseatBaseController {

    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction() {

        var useCase = new GetCurrentAuctionUseCase();

        var result = useCase.Execute();

        return result is null ? NoContent() : Ok(result);
    }

    
}

