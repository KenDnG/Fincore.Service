using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.Encryption;
using FINCORE.SERVICE.VERTEL.Repositories.EF;
using FINCORE.SERVICE.VERTEL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

				   //var connectionString = Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnAcquisition").ToString());
				   var connectionString = Decrypt.DecryptAES(DbConnectionFactory.ConnectionsStore.CONN_ACQUISITION);
				   options.UseSqlServer(connectionString);
               });
builder.Services.AddScoped<IVertel, VertelRepositoryEF>();

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
