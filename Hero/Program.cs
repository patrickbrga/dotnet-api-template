using Infra.Data;
using IoC;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DependencyRegistration.Register(Assembly.GetExecutingAssembly(), builder.Configuration, builder.Host, builder.Services);



var app = builder.Build();

app.UsePathBase(new PathString("/api"));

AppDbContext.InitializeDatabase(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().Build());
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
