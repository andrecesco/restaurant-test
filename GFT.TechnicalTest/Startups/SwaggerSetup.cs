using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace GFT.TechnicalTest.Startups
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Hiperpass", Version = "v1" });
                options.ExampleFilters();

                // BuildSecurityScheme(configuration, options);

                options.CustomOperationIds(apiDesc => apiDesc.TryGetMethodInfo(out var methodInfo) ? methodInfo.Name : null);
                options.DescribeAllEnumsAsStrings();

                var xmlFile = $"{assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
                options.AddFluentValidationRules();
            });

            services.AddSwaggerExamplesFromAssemblies(assembly);
            services.AddSwaggerGenNewtonsoftSupport();

            return services;
        }

        private static void BuildSecurityScheme(IConfiguration configuration, SwaggerGenOptions options)
        {
            var loginOptions = configuration.GetSection("AzureAD");

            var authority = loginOptions.GetValue<string>("Authority");
            var tokenEndpoints = loginOptions.GetValue<string>("Swagger");
            var accessAsUserScope = loginOptions.GetValue<string>("AccessAsUserScope");

            var configUriValue = $"{authority}/.well-known/openid-configuration";
            var authorizeUriValue = $"{tokenEndpoints}/oauth2/v2.0/authorize";
            var tokenUriValue = $"{tokenEndpoints}/oauth2/v2.0/token";

            var tokenUri = new Uri(tokenUriValue);
            var authorizeUri = new Uri(authorizeUriValue);
            var configUri = new Uri(configUriValue);

            var scheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },

                Flows = new OpenApiOAuthFlows()
                {
                    Implicit = new OpenApiOAuthFlow()
                    {
                        TokenUrl = tokenUri,
                        AuthorizationUrl = authorizeUri,
                        Scopes = new Dictionary<string, string>() { { accessAsUserScope, "Access as User" } }
                    }
                },

                OpenIdConnectUrl = configUri,

                Type = SecuritySchemeType.OAuth2,
                In = ParameterLocation.Header,

                Name = "Authorization",
                BearerFormat = "JWT",
                Scheme = "Bearer",
            };

            options.AddSecurityDefinition("Bearer", scheme);

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    { scheme, new List<string>(){ "scope" } }
                });
        }
    }
}
