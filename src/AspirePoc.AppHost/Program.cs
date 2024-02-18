
var builder = DistributedApplication.CreateBuilder(args);

var rabbitMQ = builder
    .AddRabbitMQContainer("rabbitmq-aspire", port: 5672, password: "guest");

var bookDb = builder.AddSqlServerContainer("sqlserver-aspirepoc", "MyDB@123", 1433)
    .AddDatabase("libraryDb");



builder.AddProject<Projects.AspirePoc_UI_Api>("aspirepoc.ui.api")
    .WithReference(rabbitMQ)
    .WithReference(bookDb);

builder.Build().Run();
