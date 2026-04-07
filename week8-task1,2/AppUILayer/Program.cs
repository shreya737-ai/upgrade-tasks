using DAL.Repository;
using DAL.DapperContext;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();



// DI Registration
builder.Services.AddScoped<DbConnectionFactory>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();