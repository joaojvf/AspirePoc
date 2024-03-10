var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AspirePoc_UI_Api>("aspirepoc.ui.api");

builder.Build().Run();
