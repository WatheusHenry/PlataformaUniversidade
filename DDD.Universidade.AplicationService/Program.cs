using DDD.Infra.MemoryDB;
using DDD.Infra.MemoryDB.Interfaces;
using DDD.Infra.MemoryDB.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Injection Of Controll
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IDisciplineRepository, DisciplineRepository>();
builder.Services.AddScoped<ApiContext, ApiContext>();


builder.Services.AddControllers();
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
