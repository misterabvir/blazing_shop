using Server;
using Persistence;
using Application;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddPersistence()
    .AddApplication()
    .AddServer();

builder.Build().UseServer().Run();
