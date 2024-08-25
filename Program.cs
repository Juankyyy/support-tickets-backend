using Microsoft.EntityFrameworkCore;
using SupportTickets.Data;
using SupportTickets.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Servicio de los controladores
builder.Services.AddControllers();

// Cors
builder.Services.AddCors(options=>{
    options.AddPolicy("AllowAnyOrigin",builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// Config DB
builder.Services.AddDbContext<SupportTicketsContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SupportTicketsConnection"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

// Scopes de los servicios
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Cors
app.UseCors("AllowAnyOrigin");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapear Controladores
app.MapControllers();

app.Run();