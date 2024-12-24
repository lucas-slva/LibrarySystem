using Library.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var services = new ServiceCollection();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

services.BuildServiceProvider();