using Microsoft.OpenApi.Models;

namespace ProjCampanhas.Services.Setup
{
    public static class SwaggerSetup
    {
        public static void AddSwaggerSetup(WebApplicationBuilder builder)
        {
            if (builder.Services == null) throw new ArgumentNullException(nameof(builder.Services));

            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Projeto Desenvolvimento de Campanhas",
                    Description = " NET CORE API Swagger",
                    Contact = new OpenApiContact
                    {
                        Name = "Sérgio Santos", Email = "sergiomi87st@gmail.com", Url = new Uri("https://www.linkedin.com/in/ssergiosantoss/") }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

            });
        }

        public static void UseSwaggerSetup(WebApplication app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyProject");
            });
        }
    }

}
