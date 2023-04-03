using FINCORE.HELPER.LIBRARY.Encryption;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MINIAPI.Repositories;
using FINCORE.SERVICE.MINIAPI.Repositories.Acquisition;
using FINCORE.SERVICE.MINIAPI.Repositories.EF;
using FINCORE.SERVICE.MINIAPI.Repositories.EF.Acquisition;
using FINCORE.SERVICE.MINIAPI.Repositories.EF.Acquisition.CAS;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces.CM;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces.Credit_Analyst;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentContext;
using FINCORE.SERVICE.MINIAPI.Repositories.EF;
using FINCORE.SERVICE.MINIAPI.Repositories.EF.CM;
using FINCORE.HELPER.LIBRARY.DbAccess;

namespace FINCORE.SERVICE.MINIAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.AcquisitionContext>(
               options =>
               {
				   //IConfiguration configuration = new ConfigurationBuilder()
				   //    .SetBasePath(Directory.GetCurrentDirectory())
				   //    .AddJsonFile("appsettings.json", optional: false)
				   //    .Build();

				   //var connectionString = Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnMiniAPIDB").ToString());
				   var connectionString = Decrypt.DecryptAES(DbConnectionFactory.ConnectionsStore.CONN_ACQUISITION);
				   options.UseSqlServer(connectionString, sqlServerOptionsAction => sqlServerOptionsAction.CommandTimeout(120));
               });
            builder.Services.AddDbContext<FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext.MastersContext>(
              options =>
              {
                  //IConfiguration configuration = new ConfigurationBuilder()
                  //    .SetBasePath(Directory.GetCurrentDirectory())
                  //    .AddJsonFile("appsettings.json", optional: false)
                  //    .Build();

                  //var connectionString = Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnMastApp").ToString());
				  var connectionString = Decrypt.DecryptAES(DbConnectionFactory.ConnectionsStore.CONN_MASTER);
				  options.UseSqlServer(connectionString);
              });

            builder.Services.AddDbContext<PAYMENTContext>(
                options =>
                {
                    //IConfiguration configuration = new ConfigurationBuilder()
                    //    .SetBasePath(Directory.GetCurrentDirectory())
                    //    .AddJsonFile("appsettings.json", optional: false)
                    //    .Build();

                    //var connectionString = Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnPayment").ToString());
					var connectionString = Decrypt.DecryptAES(DbConnectionFactory.ConnectionsStore.CONN_PAYMENT);
					options.UseSqlServer(connectionString);
                });

            //for Entity Framework: register your Repository and Class interface here:
            //Exp: <YourInterfaceClass, YourRepositoryEF>
            builder.Services.AddScoped<ITrCas, TrCasRepositoryEF>();
            builder.Services.AddScoped<INPPMenu, NPPMenuRepository>();
            builder.Services.AddScoped<IAcquisition, AcquisitionRepository>();
            builder.Services.AddScoped<IApproval, ApprovalRepository>();

            builder.Services.AddScoped<ICM, CMRepositoryEF>();
            builder.Services.AddScoped<ICA, CARepository>();
            builder.Services.AddScoped<IApproval, ApprovalRepository>();
            builder.Services.AddScoped<IBPKB, BPKBRepositoryEF>();

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