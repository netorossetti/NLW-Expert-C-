using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Services;

public class LoggedUser {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _repository;
    public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository) {
        _httpContextAccessor = httpContext;
        _repository = repository;
    }
    public User User() {

        var email = FromBase64String(TokenOnRequest());
        return _repository.GetUserByEmail(email);

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
