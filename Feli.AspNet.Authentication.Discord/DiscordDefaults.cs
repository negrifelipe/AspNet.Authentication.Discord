namespace Feli.AspNet.Authentication.Discord
{
    public static class DiscordDefaults
    {
        public const string AuthorizationScheme = "Discord";
        public const string DisplayName = "Discord";
        public const string AuthorizationEndpoint = "https://discord.com/api/oauth2/authorize";
        public const string TokenEndpoint = "https://discord.com/api/oauth2/token";
        public const string UserInformationEndpoint = "https://discord.com/api/users/@me";
    }
}
