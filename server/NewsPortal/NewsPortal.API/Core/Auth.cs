using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NewsPortal.API.Core
{
    public class Auth
    {
        public static void ConfigureAuth(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "NewsPortal",
                        ValidAudience = "NewsPortal",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("NewsPortalSecretKey"))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("User", policy => policy.RequireRole("User"));
            });
            
            
        }
    }
}
