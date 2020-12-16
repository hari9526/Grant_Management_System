using System.IO;
using Microsoft.Extensions.Configuration;

namespace data.Data
{
    //This class is used for obtaining the connetionstring from 
    //appsettings.development.json file in api project. 
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            var configBuilder = new ConfigurationBuilder(); 
            //var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Development.json");
            //This file is not optional. It has to be there. 
            //configBuilder.AddJsonFile(path, false);
            configBuilder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../API/appsettings.Development.json");
            var root = configBuilder.Build();
            var appsettings = root.GetSection("ConnectionStrings:DefaultConnnectionString"); 
            SqlConnectionString = appsettings.Value; 

            
        }
        public string SqlConnectionString { get; set; }
    }
}