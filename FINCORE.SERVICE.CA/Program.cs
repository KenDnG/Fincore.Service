using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.Encryption;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.SERVICE.CA.Repositories.EF;
using FINCORE.SERVICE.CA.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FINCORE.SERVICE.CAS
{
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

            builder.Services.AddDbContext<AcquisitionContext>(
                options =>
                {
					//IConfiguration configuration = new ConfigurationBuilder()
					//    .SetBasePath(Directory.GetCurrentDirectory())
					//    .AddJsonFile("appsettings.json", optional: false)
					//    .Build();

					//var connectionString = Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnAcquisition").ToString());
					var connectionString = Decrypt.DecryptAES(DbConnectionFactory.ConnectionsStore.CONN_ACQUISITION);
					options.UseSqlServer(connectionString);
                });

            builder.Services.AddScoped<IACHeader, ACHeaderRepositoryEF>();
            builder.Services.AddScoped<IACDetail, ACDetailRepositoryEF>();
            builder.Services.AddScoped<ICMODealer, CMODealerRepositoryEF>();
            builder.Services.AddScoped<ITrCAS_CreditAnalyst, TrCAS_CreditAnalystEF>();
            builder.Services.AddScoped<ICACar, CACarRepositoryEF>();

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