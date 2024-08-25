var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CK_Central_API_GrabMart>("ck-central-api-grabmart");

builder.AddProject<Projects.CK_Central_API_CMS>("ck-central-api-cms");

builder.AddProject<Projects.CK_Central_API_GrabMart_Menu>("ck-central-api-grabmart-menu");

builder.AddProject<Projects.CK_Central_API_GrabMart_Order>("ck-central-api-grabmart-order");

builder.AddProject<Projects.CK_Central_API_GrabMart_Store>("ck-central-api-grabmart-store");

builder.AddProject<Projects.CK_Central_API_GrabMart_Campaign>("ck-central-api-grabmart-campaign");

builder.AddProject<Projects.CK_Central_API_GrabMart_Authorisation>("ck-central-api-grabmart-authorisation");

builder.AddProject<Projects.CK_Central_API_GrabMart_Job>("ck-central-api-grabmart-job");

builder.AddProject<Projects.CK_Central_API_POS>("ck-central-api-pos");

builder.AddProject<Projects.CK_Central_API_CMS_Portal>("ck-central-api-cms-portal");

builder.AddProject<Projects.CK_Central_API_CMS_Job>("ck-central-api-cms-job");

builder.AddProject<Projects.CK_Central_API_POS_GrabMart_Order>("ck-central-api-pos-grabmart-order");

builder.AddProject<Projects.CK_Central_API_POS_GrabMart_Stock>("ck-central-api-pos-grabmart-stock");

builder.AddProject<Projects.CK_Central_API_CMS_MasterData>("ck-central-api-cms-masterdata");

builder.AddProject<Projects.CK_Central_API_CMS_HealthCheck>("ck-central-api-cms-healthcheck");

builder.AddProject<Projects.CK_Central_API_GrabMart_HealthCheck>("ck-central-api-grabmart-healthcheck");

builder.AddProject<Projects.CK_Central_API_CMS_Generate>("ck-central-api-cms-generate");

builder.AddProject<Projects.CK_Central_API_POS_HealthCheck>("ck-central-api-pos-healthcheck");

builder.AddProject<Projects.CK_Central_API_CMS_Auth>("ck-central-api-cms-auth");

builder.Build().Run();
