using Core.Database;
using UserTestingAPI.Core.Exceptions;
using UserTestingAPI.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("front" ,policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterDependencies(builder.Configuration);

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var myDependency = services.GetRequiredService<IMigrationsManager>();

    //Use the service
    myDependency?.MigrateDbIfNeeded().Wait();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpLogging(); 

app.UseHttpsRedirection();

app.UseCors("front");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
 

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.Run();