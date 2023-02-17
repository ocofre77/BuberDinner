using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _iJwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator iJwtTokenGenerator, IUserRepository userRepository = null)
    {
        _iJwtTokenGenerator = iJwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //check if user already exists 
        //Create user (generate unique ID)
        //Create jwt token 
        Guid userId = Guid.NewGuid();
        var token = _iJwtTokenGenerator.GenerateToken(userId, firstName,lastName);
        return new AuthenticationResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            token
        );
    }

    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "toker"
        );
    }
}