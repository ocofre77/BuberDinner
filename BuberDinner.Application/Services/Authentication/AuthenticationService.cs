using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

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
        //1. check if user already exists 
        if(_userRepository.GetUserByEmail(email) is not null ){
            //return new AuthenticationResult(false,"User already exists");
            throw new Exception("User with given email already exists");
        }
        //2. Create user (generate unique ID)
        var user = new User{
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
        _userRepository.Add(user);

        //3. Create jwt token 
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
        //1. Validate the user exists
        if(_userRepository.GetUserByEmail(email) is not User user ){
            //return new AuthenticationResult(false,"User already exists");
            throw new Exception("User with given email already exists");
        }
        //2. Validate the password is correct
        if(user.Password == password){
            throw new Exception("Password is invalid");
        }
 
        //3. Create JWT token
        var token = _iJwtTokenGenerator.GenerateToken( user.Id, user.FirstName, user.LastName );
        return new AuthenticationResult(
            user.Id,
            user.FirstName,
            user.LastName,
            email,
            token
        );
    }
}