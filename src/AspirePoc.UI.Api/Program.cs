using AspirePoc.Core;
using AspirePoc.Infrastructure.RabbitMQ;
using Microsoft.EntityFrameworkCore;
using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Infrastructure.SqlServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

SetupInfrastructure();
builder.Services.CoreProjectSetup();
builder.Services.RabbitMQSetup(builder.Configuration);


var app = builder.Build();

app.MapDefaultEndpoints();
if (app.Environment.IsDevelopment())
{
    using var serviceScope = app.Services.CreateScope();
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
    await dbContext.Database.MigrateAsync();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

void SetupInfrastructure()
{
    builder.AddSqlServerDbContext<ApplicationContext>("libraryDb");
    builder.Services.AddScoped<IBookRepository, BookRepository>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
}