using System.Text.Json.Serialization;
using eShopApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<StoreDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("local"));
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
// app.UseSwaggerUI();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    // Optionally, you can also configure the Swagger UI route prefix
    // c.RoutePrefix = "swagger";
});
// }

// app.UseHttpsRedirection();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

// seed data if there's not data in db already
try
{
    context.Database.Migrate();
    DbInitializer.Initialize(context);
}
catch (Exception ex)
{
    logger.LogError(ex, "A problem occurred during migration");
}

app.MapControllers();

app.Run();

