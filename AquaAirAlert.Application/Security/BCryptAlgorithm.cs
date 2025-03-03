using AquaAirAlert.Infrastructure.Data;

namespace AquaAirAlert.Application.Security;

public class BCryptAlgorithm
{
    public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

    public bool Verify (string password, User user) => BCrypt.Net.BCrypt.Verify(password, user.Password);
}