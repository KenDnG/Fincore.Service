using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.Encryption;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MastersContext>(
    options =>
    {
		//IConfiguration configuration = new ConfigurationBuilder()
		//    .SetBasePath(Directory.GetCurrentDirectory())
		//    .AddJsonFile("appsettings.json", optional: false)
		//    .Build();

		//var connectionString = Decrypt.DecryptAES(configuration.GetValue<string>("ConnectionStrings:ConnMasters").ToString());
		var connectionString = Decrypt.DecryptAES(DbConnectionFactory.ConnectionsStore.CONN_MASTER);
		options.UseSqlServer(connectionString);
    });
builder.Services.AddScoped<IMsProducts, MsProductsRepositoryEF>();
builder.Services.AddScoped<IMsNationality, MsNationalityRepository>();
builder.Services.AddScoped<IMsLocation, MsLocationRepository>();
builder.Services.AddScoped<IMsIdentityType, MsIdentityTypeRepositoryEF>();
builder.Services.AddScoped<IMsPaymentPoint, MsPaymentPointRepositoryEF>();
builder.Services.AddScoped<IMsMailToSource, MsMailToSourceRepository>();
builder.Services.AddScoped<IMSMenu, MSMenuRepository>();
builder.Services.AddScoped<IMSCompanyBranch, MSCompanyBranchRepository>();
builder.Services.AddScoped<IMsDealerJobTitle, MsDealerJobTitleRepository>();
builder.Services.AddScoped<IMsDealerPersonnel, MsDealerPersonnelRepository>();
builder.Services.AddScoped<IMsBPKBLocation, MsBPKBLocationRepository>();
builder.Services.AddScoped<IMsBPKBReason, MsBPKBReasonRepository>();
builder.Services.AddScoped<IMsBPKBReceiver, MsBPKBReceiverRepository>();
builder.Services.AddScoped<IMsTypeOfServiceBureauNecessity, MsTypeOfServiceBureauNecessityRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();