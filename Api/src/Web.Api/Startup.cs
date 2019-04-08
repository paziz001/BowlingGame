using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Api.Commands;
using Web.Api.Validators;

namespace Web.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCors(options =>
                    {
                        options.AddPolicy(MyAllowSpecificOrigins,
                            builder =>
                            {
                                builder
                                    .WithOrigins("http://localhost:4200")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                            });
                    })
                .AddSingleton<CommandHandler>()
                .AddTransient<IValidator<CalculateRoundScores>, CalculateRoundScoresValidator>()
                .AddMvc()
                .AddFluentValidation()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.Use(async (context, next) =>
                {
                    await next.Invoke();
                }).UseDeveloperExceptionPage();
            }
            

            app.UseHttpsRedirection()
                .UseCors(MyAllowSpecificOrigins)
                .UseMvcWithDefaultRoute();
        }
    }
}