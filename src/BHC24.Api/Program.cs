using BHC24.Api.Extensions;
using BHC24.Api.Persistence;
using BHC24.Api.Persistence.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BhcDbContext>();

builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<BhcDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddCors(o => o.AddPolicy("MyPolicy", policyBuilder =>
{
    policyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

builder.Services.AddControllers();

builder.Services.AddAntiforgery();

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Map("/", () => Results.Redirect("/swagger"));

app.UseRouting();
app.UseAntiforgery();
app.UseCors("MyPolicy");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<BhcDbContext>();
context!.Database.Migrate();


app.Run();