using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace Feli.AspNet.Authentication.Discord
{
    public class DiscordHandler : OAuthHandler<DiscordOptions>
    {
        public DiscordHandler(IOptionsMonitor<DiscordOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            using HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, Options.UserInformationEndpoint);
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);

            using HttpResponseMessage responseMessage = await Backchannel.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead, Context.RequestAborted);
            if(!responseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"An error occurred when retrieving Discord user information ({responseMessage.StatusCode}). Please check if the authentication information is correct.");
            }

            using JsonDocument payload = JsonDocument.Parse(await responseMessage.Content.ReadAsStringAsync());

            OAuthCreatingTicketContext context = new OAuthCreatingTicketContext(new ClaimsPrincipal(identity), properties, Context, Scheme, Options, Backchannel, tokens, payload.RootElement);
            context.RunClaimActions();

            await Events.OnCreatingTicket(context);

            return new AuthenticationTicket(context.Principal, context.Properties, Scheme.Name);
        }
    }
}
