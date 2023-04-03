using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.Encryption;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.SERVICE.CREDITS.Repositories.EF;
using FINCORE.SERVICE.CREDITS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); //for handling reference loop Entity

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
//for Entity Framework: register your Repository and Class interface here:
//Exp: <YourInterfaceClass, YourRepositoryEF>
builder.Services.AddScoped<ITrCas, TrCasRepositoryEF>();
builder.Services.AddScoped<IAcquisition, AcquisitionRepository>();

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