using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.Encryption;
using FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentContext;
using FINCORE.SERVICE.CSSESSION.Repositories.EF;
using FINCORE.SERVICE.CSSESSION.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace FINCORE.SERVICE.CSSESSION
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            //builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

           builder.Services.AddDbContext<PAYMENTContext>(
            options =>
            {
				//IConfiguration configuration = new ConfigurationBuilder()
				//    .SetBasePath(Directory.GetCurrentDirectory())
				//    .AddJsonFile("appsettings.json", optional: false)
				//    .Build();

				//var connectionString = Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnPayment").ToString());
				var connectionString = Decrypt.DecryptAES(DbConnectionFactory.ConnectionsStore.CONN_PAYMENT);
				options.UseSqlServer(connectionString, sqlOption => sqlOption.CommandTimeout(120));
            });

            builder.Services.AddScoped<ICashierSessionRepository, CashierSessionRepository>();
            builder.Services.AddScoped<ICashierSessionVerify, CashierSessionVerifyRepository>();

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
}