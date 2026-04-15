using ContactManagementAPI.Repositories;

using ContactManagementAPI.Services;

using week9_task2.Repository.IContactRepository;
using week9_task2.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// 🔥 Enable Memory Cache
builder.Services.AddMemoryCache();

// DI
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();