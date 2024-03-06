using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TokenValidatedContext = Microsoft.AspNetCore.Authentication.JwtBearer.TokenValidatedContext;

namespace IdentityServerAspNetIdentity
{
    public class CustomJwtBearerEvents : JwtBearerEvents
    {
        public override async Task TokenValidated(TokenValidatedContext context)
        {
            var claims = context.Principal.Claims.ToList();
            claims.Add(new Claim("key", "value"));
            context.Principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Bearer"));
        }
    }
}
