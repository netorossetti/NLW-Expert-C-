using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.Services;

public class LoggedUser {
    private readonly IHttpContextAccessor _httpContextAccessor;
    public LoggedUser(IHttpContextAccessor httpContext) {
        _httpContextAccessor = httpContext;
    }
    public User User() {

        var repository = new RockeseatAuctionDbContext();
        var email = FromBase64String(TokenOnRequest());
        return repository.Users.First(u => u.Email.Equals(email));

    }
    private string TokenOnRequest() {
        var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
        if (string.IsNullOrEmpty(authentication)) {
            throw new Exception("Token is missing.");
        }

        //"Bearer Y3Jpc3RpYW5vQGNyaXN0aWFuby5jb20="
        return authentication["Bearer ".Length..];
    }

    private string FromBase64String(string base64) {
        var data = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(data);

    }
}
