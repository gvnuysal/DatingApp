using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
     public static class SwaggerExtensions
     {
          public static IServiceCollection AddSwaggerServices(this IServiceCollection services, IConfiguration config)
          {
               services.AddSwaggerGen(options =>
                 {
                      options.SwaggerDoc("v1", new OpenApiInfo
                      {
                           Title = "API",
                           Version = "v1",
                           Contact = new OpenApiContact
                           {
                                Name = "İsminiz",
                                Email = "mail adresiniz",
                                Url = new Uri("https://www.linkedin.com/in/ignaciojv/")
                           },
                           License = new OpenApiLicense
                           {
                                Name = "MIT",
                                Url = new Uri("https://github.com/ignaciojvig/ChatAPI/blob/master/LICENSE")
                           }
                      });
                      options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                      {
                           Name = "Authorization",
                           Type = SecuritySchemeType.ApiKey,
                           Scheme = "Bearer",
                           BearerFormat = "JWT",
                           In = ParameterLocation.Header,
                           Description = ""
                      });

                      options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                          {
                              new OpenApiSecurityScheme{
                                  Reference=new OpenApiReference{Type=ReferenceType.SecurityScheme,Id="Bearer"}
                              },
                              new string[]{}
                          }
                      });

                      options.DocInclusionPredicate((docName, description) => true);
                 });

               return services;
          }
     }
}