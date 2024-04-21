var builder = DistributedApplication.CreateBuilder(args);

var rabbitMQPwd = builder.AddParameter("rabbitMQPwd");

var rabbitMQ = builder.AddRabbitMQ("rabbitmq-aspire", password: rabbitMQPwd)
    .WithManagementPlugin();
var db1 = builder.AddSqlServer("sql-aspire").AddDatabase("libraryDb");

builder.AddProject<Projects.AspirePoc_UI_Api>("aspirepoc-ui-api")
        .WithReference(rabbitMQ)
        .WithReference(db1);

builder.Build().Run();