﻿using Microsoft.AspNetCore.Authentication.JwtBearer;

using SFC.GeneralTemplate.Api.Infrastructure.Authentication;
using SFC.GeneralTemplate.Api.Infrastructure.Extensions;
using SFC.GeneralTemplate.Infrastructure.Extensions;
using SFC.GeneralTemplate.Infrastructure.Settings;

namespace SFC.GeneralTemplate.Api.Infrastructure.Extensions;

public static class AuthenticationExtensions
{
    private const string ValidJwtHeaderTyp = "at+jwt";

    public static void AddAuthentication(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        IdentitySettings identitySettings = builder.Configuration.GetIdentitySettings();

        builder.Services.AddSingleton<AuthenticationJwtBearerEvents>();

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
             {
                 if (!builder.Environment.IsDevelopment() || builder.Configuration.UseAuthentication())
                 {
                     options.Authority = identitySettings.Authority;
                     options.Audience = identitySettings.Audience;
                     options.TokenValidationParameters = new()
                     {
                         ValidateAudience = true,
                         NameClaimType = "name",
                         ValidTypes = [ValidJwtHeaderTyp]
                     };
                 }

                 options.EventsType = typeof(AuthenticationJwtBearerEvents);
             }
         );

        builder.Services.AddAuthorization(options =>
        {
            options.AddGeneralPolicy(identitySettings.RequireClaims);
            options.AddOwnGeneralTemplatePolicy(identitySettings.RequireClaims);
        });
    }
}
