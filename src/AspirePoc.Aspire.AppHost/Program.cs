var builder = DistributedApplication.CreateBuilder(args);

var rabbitMQ = builder
    .AddRabbitMQContainer("rabbitmq-aspire", port: 5672, password: "guest");

builder.AddProject<Projects.AspirePoc_UI_Api>("aspirepoc.ui.api")
        .WithReference(rabbitMQ);

builder.Build().Run();
