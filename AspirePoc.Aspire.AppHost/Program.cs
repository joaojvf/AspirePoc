var builder = DistributedApplication.CreateBuilder(args);

var rabbitMQ = builder
    .AddRabbitMQ("rabbitmq-aspire", port: 5672);

var db1 = builder.AddSqlServer("sql-aspire").AddDatabase("libraryDb");

builder.AddProject<Projects.AspirePoc_UI_Api>("aspirepoc-ui-api")
        .WithReference(rabbitMQ)
        .WithReference(db1);

//builder.AddProject<Projects.AspirePoc_UI_Api>("aspirepoc-ui-api");

builder.Build().Run();
