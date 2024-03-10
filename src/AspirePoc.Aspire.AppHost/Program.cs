var builder = DistributedApplication.CreateBuilder(args);

var rabbitMQ = builder
    .AddRabbitMQContainer("rabbitmq-aspire", port: 5672, password: "guest");
var db1 = builder.AddSqlServer("sql-aspire").AddDatabase("libraryDb");

builder.AddProject<Projects.AspirePoc_UI_Api>("aspirepoc.ui.api")
        .WithReference(rabbitMQ)
        .WithReference(db1);

builder.Build().Run();
