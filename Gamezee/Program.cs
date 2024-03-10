using Gamezee.Application;
using Gamezee.Infrastructure.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddCors(opt => opt.AddPolicy(name: "ClientApp", configurePolicy: policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
}));

//DI services configurations
builder.Services.AddDatabase(connnectionString);
builder.Services.AddApplication();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //options.DefaultChallengeScheme = GoogleDefaults;
})
          .AddJwtBearer(options =>
          {
              options.SaveToken = true;
              options.TokenValidationParameters = new TokenValidationParameters()
              {
                  ValidateIssuer = false,
                  ValidateAudience = false,
                  RequireExpirationTime = false,
                  ValidateLifetime = false,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DjPxYgkhUdQJczVusAvUEXCrycVxaJ12345678901234567890123456789012dQijj"))
              };
          });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMapIdentityApi();

app.UseCors("ClientApp");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
