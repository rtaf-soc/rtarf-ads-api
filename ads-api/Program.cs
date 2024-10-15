using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Diagnostics.CodeAnalysis;
using Its.Ads.Api.Database.Seeders;
using Its.Ads.Api.Database;
using Its.Ads.Api.Services;
using Its.Ads.Api.Database.Repositories;
using Its.Ads.Api.Authorizations;
using Its.Ads.Api.Authentications;

namespace Its.Ads.Api
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        public static void Main(string[] args)
        {
            var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            Log.Logger = log;

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

            var cfg = builder.Configuration;
            var connStr = $"Host={cfg["PostgreSQL:Host"]}; Database={cfg["PostgreSQL:Database"]}; Username={cfg["PostgreSQL:User"]}; Password={cfg["PostgreSQL:Password"]}";

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(connStr));
            builder.Services.AddTransient<DataSeeder>();

            builder.Services.AddScoped<IDataContext, DataContext>();
            builder.Services.AddScoped<IApiKeyService, ApiKeyService>();
            builder.Services.AddScoped<IOrganizationService, OrganizationService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IWorkflowService, WorkflowService>();
            builder.Services.AddScoped<IBlacklistService, BlacklistService>();
            builder.Services.AddScoped<IIpMapService, IpMapService>();

            builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            builder.Services.AddScoped<IApiKeyRepository, ApiKeyRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IWorkflowRepository, WorkflowRepository>();
            builder.Services.AddScoped<IBlacklistRepository, BlacklistRepository>();
            builder.Services.AddScoped<IIpMapRepository, IpMapRepository>();

            builder.Services.AddTransient<IAuthorizationHandler, GenericRbacHandler>();
            builder.Services.AddScoped<IBasicAuthenticationRepo, BasicAuthenticationRepo>();
            builder.Services.AddScoped<IBearerAuthenticationRepo, BearerAuthenticationRepo>();

            builder.Services.AddAuthentication("BasicOrBearer")
                .AddScheme<AuthenticationSchemeOptions, AuthenticationHandlerProxy>("BasicOrBearer", null);

            builder.Services.AddAuthorization(options => {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder("BasicOrBearer");
                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();

                options.AddPolicy("GenericRolePolicy", policy => policy.AddRequirements(new GenericRbacRequirement()));
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                dbContext.Database.Migrate();

                var service = scope.ServiceProvider.GetRequiredService<DataSeeder>();
                service.Seed();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
