var builder = DistributedApplication.CreateBuilder(args);

var rabbitMQPwd = builder.AddParameter("rabbitMQPwd");
var sqlPwd = builder.AddParameter("sql-pwd");

var db1 = builder
    .AddSqlServer("sql-aspire", password: sqlPwd, port: 1433)
    .WithDataVolume()
    .AddDatabase("libraryDb");

var migration = builder
    .AddProject<Projects.AspirePoc_Infrastructure_MigrationService>("migration")
    .WithReference(db1);

var rabbitMQ = builder
    .AddRabbitMQ("rabbitmq-aspire", password: rabbitMQPwd)
    .WithManagementPlugin();

builder.AddProject<Projects.AspirePoc_UI_Api>("aspirepoc-ui-api")
        .WithReference(rabbitMQ)
        .WithReference(db1)
        .WithReference(migration);

builder.Build().Run();