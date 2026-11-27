using IoC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using AlchemyCalculator.Models.Seguranca;
using AlchemyCalculator.Models.Seguranca.JWT;
using System.Data;

namespace TemplateFTI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // JWT TOKEN
        var configuracoesToken = new TokenConfigurations();
        new ConfigureFromConfigurationOptions<TokenConfigurations>(builder.Configuration.GetSection("TokenConfigurations")).Configure(configuracoesToken);

        var servicos = builder.Services;
        servicos.RegistrarServicos(); // => IoC

        var signingConfigurations = new SigningConfigurations(configuracoesToken.SecretJwtKey ?? "");
        servicos.AddSingleton(signingConfigurations);
        servicos.AddSingleton(configuracoesToken);
        servicos.AddAuthentication(authOptions =>
        {
            authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(bearerOptions =>
        {
            var paramsValidation = bearerOptions.TokenValidationParameters;
            paramsValidation.IssuerSigningKey = signingConfigurations.Key;
            paramsValidation.ValidAudience = configuracoesToken.Audience;
            paramsValidation.ValidIssuer = configuracoesToken.Issuer;

            paramsValidation.ValidateIssuerSigningKey = true;
            paramsValidation.ValidateLifetime = true;

            // Tempo de tolerância para a expiração de um token (utilizado
            // caso haja problemas de sincronismo de horário entre diferentes
            // computadores envolvidos no processo de comunicação)
            // paramsValidation.ClockSkew = TimeSpan.Zero;
        });

        servicos.AddAuthorization(auth =>
        {
            auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser().Build());
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

