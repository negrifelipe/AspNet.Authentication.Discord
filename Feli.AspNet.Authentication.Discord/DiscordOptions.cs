using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Feli.AspNet.Authentication.Discord
{
    public class DiscordOptions : OAuthOptions
    {
        public DiscordOptions()
        {
            CallbackPath = new PathString("/signin-discord");

            AuthorizationEndpoint = DiscordDefaults.AuthorizationEndpoint;
            TokenEndpoint = DiscordDefaults.TokenEndpoint;
            UserInformationEndpoint = DiscordDefaults.UserInformationEndpoint;

            Scope.Add("identify");
            Scope.Add("email");

            ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            ClaimActions.MapJsonKey(ClaimTypes.Name, "username");
            ClaimActions.MapJsonKey(ClaimTypes.Email, "email");
            ClaimActions.MapJsonKey("urn:discord:discriminator", "discriminator");
            ClaimActions.MapJsonKey("urn:discord:avatar", "avatar");
            ClaimActions.MapJsonKey("urn:discord:verified", "verified");
        }
    }
}
