using Library.Application.Interfaces;
using Library.Application.Services;
using Library.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var services = new ServiceCollection();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// DbContext
services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

// Services
services.AddScoped<IBookService, BookService>();
services.AddScoped<ILoanService, LoanService>();
services.AddScoped<IUserService, UserService>();

services.BuildServiceProvider();