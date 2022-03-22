using Feli.AspNet.Authentication.Discord;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.Events.OnSignedIn = async (context) =>
    {
        foreach(var claim in context.Principal.Claims)
        {
            Console.WriteLine($"Type: {claim.Type}. Value: {claim.Value}");
        }
    };
})
.AddDiscord(options =>
{
    options.ClientId = "your client";
    options.ClientSecret = "your secret";
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
