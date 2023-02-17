namespace BuberDinner.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LasttName,
    string Email,
    string Token
);
