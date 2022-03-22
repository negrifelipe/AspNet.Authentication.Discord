# AspNet 0Auth with Discord

ASP.NET Core middleware that enables an application to support Discord's OAuth 2.0 authentication workflow.

This package is based on [aspnet](https://github.com/dotnet/aspnetcore/tree/main/src/Security/Authentication) OAuth authentication middlewares

## Installation
```
dotnet add package Feli.AspNet.Authentication.Discord
```

## Setup Auth

You can easily use discord oauth using the AddDiscord method.

Here you have an [example](https://github.com/01-Feli/AspNet.Authentication.Discord/blob/main/src/Example/Program.cs#L8).

## Setup a developer application, getting its client id, secret and adding the redirects
- First register the application [here](https://discord.com/developers/applications).
- Navigate to the **OAuth2** section in your application.
- Then copy its **Client Id** and generate the **Client Secret**. So you can use them inside the c# project.
- Now add in the **Redirects** section inside the **OAuth2** section: https://your_url/signin-discord.

## License

[MIT](https://github.com/01-Feli/AspNet.Authentication.Discord/blob/main/LICENSE)
