using DBLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {

    }
}


//var configurationBuilder = new ConfigurationBuilder();
//configurationBuilder.AddJsonFile("appsettings.json", optional:false , reloadOnChange: true);

//var _configuration= configurationBuilder.Build();
//var services= new ServiceCollection();
//services.AddDbContext<StationeryContext>(options=>options.UseSqlServer(_configuration.GetConnectionString("StationeryDB")));
