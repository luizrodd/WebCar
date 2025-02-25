using Microsoft.EntityFrameworkCore;
using WebCar.Application.Application.Infrastructure;
using WebCar.Application.Application.Queries;
using WebCar.Application.Application.Services;
using WebCar.Domain.Interfaces;
using WebCar.Domain.Repositories;
using WebCar.Infrastructure.Data;
using WebCar.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped(provider =>
    new SqlConnectionProvider(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFileManagerService, FileManagerService>();
builder.Services.AddScoped<IFileSystemManager, FileSystemManager>();
builder.Services.AddScoped(typeof(IExternalSourceRepository<,>), typeof(ExternalSourceRepository<,>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.AddScoped<IPostQueries,  PostQueries>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("*")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

using (var Scope = app.Services.CreateScope())
{
    var context = Scope.ServiceProvider.GetRequiredService<ApplicationDataContext>();
    context.Database.Migrate();
}
app.UseCors("AllowSpecificOrigin");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
