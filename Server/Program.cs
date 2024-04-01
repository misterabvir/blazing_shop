using Server;
using Persistence;
using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddPersistence(builder.Configuration)
    .AddApplication()
    .AddServer();

builder.Build().UseServer().Run();
