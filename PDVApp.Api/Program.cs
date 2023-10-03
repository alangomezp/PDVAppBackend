
using BusinessLogic.Domain.Aggregates;
using BusinessLogic.Domain.Core;
using BusinessLogic.Domain.Services.Definition;
using BusinessLogic.Domain.Services.Implementation;
using BusinessLogic.Persistence;
using BusinessLogic.Persistence.Repository.Definition;
using BusinessLogic.Persistence.Repository.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PDVApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cors = "customCors";
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: cors,
                                  builder =>
                                  {
                                      builder.WithOrigins("*");
                                      builder.WithHeaders("*");
                                      builder.WithMethods("*");
                                  });
            });

            // Add services to the container.
            builder.Services.AddScoped<IRepositoryServices<Student>, RepositoryServices<Student>>();
            builder.Services.AddScoped<IRepositoryServices<User>, RepositoryServices<User>>();
            builder.Services.AddScoped<IRepositoryServices<BagFund>, RepositoryServices<BagFund>>();
            builder.Services.AddScoped<IRepositoryServices<FundAccount>, RepositoryServices<FundAccount>>();
            builder.Services.AddScoped<IRepositoryServices<Payments>, RepositoryServices<Payments>>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ILoginServices, LoginServices>();
            builder.Services.AddScoped<IStudentServices, StudentServices>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IPaymentsServices, PaymentServices>();
            builder.Services.AddScoped<IPaymentsRepository, PaymentsRepository>();
            builder.Services.AddScoped<IBagFundServices, BagFundServices>();
            builder.Services.AddScoped<IBagFundRepository, BagFundRepository>();
            builder.Services.AddScoped<IFundAccountsRepository, FundAccountsRepository>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Inject appsettings.json
            builder.Configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);

            builder.Services.Configure<JwtToken>(builder.Configuration.GetSection("Jwt"));
            //Db Context
            builder.Services.AddSqlServer<DatabaseContext>(builder.Configuration.GetConnectionString("DbConnection"));
            //JWT Auth
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration.GetSection("Jwt").Get<JwtToken>()!.Issuer,
                        ValidAudience = builder.Configuration.GetSection("Jwt").Get<JwtToken>()!.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt").Get<JwtToken>()!.Key))
                    };
                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(cors);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}