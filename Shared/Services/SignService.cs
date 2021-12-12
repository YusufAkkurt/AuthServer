using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AuthServer.Shared.Services
{
    public static class SignService
    {
        public static SecurityKey GetSymmetricSecurityKey(string securityKey) => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}
