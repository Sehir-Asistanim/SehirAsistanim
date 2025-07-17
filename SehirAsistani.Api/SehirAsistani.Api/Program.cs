using Microsoft.EntityFrameworkCore;
using NetTopologySuite; 
using NetTopologySuite.Geometries;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure; 
using SehirAsistanim.Domain.Enums; 
using SehirAsistanim.Domain.Interfaces;
using SehirAsistanim.Infrastructure.Services;
using SehirAsistanim.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

#region enumMapping+SqlConnection
NpgsqlConnection.GlobalTypeMapper.MapEnum<rolturu>("rolturu");

builder.Services.AddDbContext<SehirAsistaniDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsqlOptions =>
        {
            npgsqlOptions.UseNetTopologySuite(); // Harita desteði
            npgsqlOptions.MapEnum<rolturu>("rolturu"); // PostgreSQL enum'u ile C# enum'unu eþleþtir
        })
);
#endregion


#region Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<KullaniciService>();

#endregion



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
