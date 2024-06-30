var builder = DistributedApplication.CreateBuilder(args);

var rabbitMQPwd = builder.AddParameter("rabbitMQPwd");
var sqlPwd = builder.AddParameter("sql-pwd");

var rabbitMQ = builder.AddRabbitMQ("rabbitmq-aspire", password: rabbitMQPwd)
    .WithManagementPlugin();

var db1 = builder
    .AddSqlServer("sql-aspire", password: sqlPwd)
    .WithDataVolume()
    .AddDatabase("libraryDb");

builder.AddProject<Projects.AspirePoc_UI_Api>("aspirepoc-ui-api")
        .WithReference(rabbitMQ)
        .WithReference(db1);

builder.Build().Run();