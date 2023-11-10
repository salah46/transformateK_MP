using Microsoft.EntityFrameworkCore;
using transformatek_MP.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//"Data Source=/home/salah/Desktop/transformatek_MP/Database/tt_mp_db"
// using Microsoft.EntityFrameworkCore;
builder.Services.AddDbContext<TransforamTek_MP_Context>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TransforamTek_MP")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
