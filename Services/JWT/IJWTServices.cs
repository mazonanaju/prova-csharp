namespace Turistando.Services.JWT;

public interface IJWTService
{
    string CreateToken(UserToAuth data);
}