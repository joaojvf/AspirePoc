using AspirePoc.Core;
using AspirePoc.Infrastructure.RabbitMQ;
using Microsoft.EntityFrameworkCore;
using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Infrastructure.SqlServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddSqlServerClient("sql-aspire");
builder.AddRabbitMQ("rabbitmq-aspire");

builder.Services.RabbitMQSetup(builder.Configuration);
SetupInfrastructure();
builder.Services.CoreProjectSetup();

var app = builder.Build();

app.MapDefaultEndpoints();
if (app.Environment.IsDevelopment())
{
    try
    {
        using var serviceScope = app.Services.CreateScope();
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
        await dbContext.Database.MigrateAsync();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }


    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

void SetupInfrastructure()
{
    builder.AddSqlServerDbContext<ApplicationContext>("sql-aspire");
    builder.Services.AddScoped<IBookRepository, BookRepository>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
}