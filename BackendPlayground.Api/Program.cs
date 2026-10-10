using BackendPlayground.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi().AddControllers();
builder.Services.AddScoped<CustomerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();