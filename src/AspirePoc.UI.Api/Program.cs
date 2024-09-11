using AspirePoc.Core;
using AspirePoc.Infrastructure.RabbitMQ;
using AspirePoc.Infrastructure.SqlServer;
using Microsoft.EntityFrameworkCore;
using AspirePoc.Core.Abstractions.Repositories;
using AspirePoc.Infrastructure.SqlServer.Repositories;
using AspirePoc.UI.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

SetupInfrastructure();
builder.Services.CoreProjectSetup();
builder.Services.RabbitMQSetup(builder.Configuration);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


var app = builder.Build();

app.MapDefaultEndpoints();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

void SetupInfrastructure()
{
    //builder.AddSqlServerDbContext<ApplicationContext>("libraryDb");

    builder.Services.AddDbContextPool<ApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("libraryDb"), sqlOptions =>
    {
        // Workaround for https://github.com/dotnet/aspire/issues/1023
        sqlOptions.ExecutionStrategy(c => new RetryingSqlServerRetryingExecutionStrategy(c));
    }));
    builder.EnrichSqlServerDbContext<ApplicationContext>(settings =>
    // Disable Aspire default retries as we're using a custom execution strategy
    settings.DisableRetry = true);

    builder.Services.AddScoped<IBookRepository, BookRepository>();
    builder.Services.AddScoped<IReadModelBookRepository, ReadModelBookRepository>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
    builder.Services.AddScoped<IStoredEventsRepository, StoredEventsRepository>();
    builder.Services.SetupInfraByAssembly();
}