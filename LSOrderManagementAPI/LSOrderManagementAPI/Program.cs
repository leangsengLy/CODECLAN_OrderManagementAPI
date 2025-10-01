using LSOrderManagementAPI;
using LSOrderManagementAPI.ApiReponse;
using LSOrderManagementAPI.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//get value JWT from appsetting.json
//var jwtSettings = builder.Configuration.GetSection("Jwt");
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        ValidAudience = builder.Configuration["Jwt:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//    };
//});


//// Authorization with roles
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));
//    options.AddPolicy("StaffOnly", policy => policy.RequireRole("staff"));
//});

//service to connect with connection string that we store in appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


////prevent method when client sent HTTP method not match our api
app.UseStatusCodePages(async context =>
{
    var response = context.HttpContext.Response;

    Console.WriteLine(response);
    if (response.StatusCode == StatusCodes.Status405MethodNotAllowed)
    {
        response.ContentType = "application/json";
        await response.WriteAsync("{\"error\":\"HTTP method not allowed for this endpoint.\"}");
    }
    else if (response.StatusCode == StatusCodes.Status404NotFound)
    {
        response.ContentType = "application/json";
        await response.WriteAsync("{\"error\":\"Endpoint not found.\"}");
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
