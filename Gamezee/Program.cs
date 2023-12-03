using Gamezee.Infrastructure.Database;
using Gamezee.Application;
using Gamezee.Presentation.RestAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(_AssemblyReference).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddCors(opt => opt.AddPolicy(name: "ClientApp", configurePolicy: policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

//DI services configuration
builder.Services.AddDatabase(connnectionString);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMapIdentityApi();

app.UseAuthorization();
app.UseCors("ClientApp");

app.MapControllers();

app.Run();
