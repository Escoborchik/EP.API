using EP.Application.Infrastructure;
using EP.Application.Services;
using EP.DataAccess;
using EP.DataAccess.Repositories;
using EP.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EP.API
{
    public static class RegisterServices
    {
        public static void RegisterAppServices(this IServiceCollection services,
            string connection)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysupersecret_secretsecretsecretkey!123"))


                    };
                });
            services.AddAuthorization();
            services.AddDbContext<EPDbContext>(options => options.UseNpgsql(connection));
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IEducationProgramsRepository, EducationProgramsRepository>();
            services.AddScoped<IModulesRepository, ModulesRepository>();
            services.AddScoped<IHeadsRepository, HeadsRepository>();
            services.AddScoped<IInstitutesRepository, InstitutesRepository>();
            services.AddScoped<IEducationProgramsService, EducationProgramsService>();
            services.AddScoped<IModulesService, ModulesService>();
            services.AddScoped<IHeadsService, HeadsService>();
            services.AddScoped<IInstitutesService, InstitutesService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            
        }
    }
}
