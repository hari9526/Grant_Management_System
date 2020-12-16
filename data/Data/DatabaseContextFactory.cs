using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace data.Data
{
    //This class is for handling migrations from data layer 
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        //This is the class that Entityframework will look when its creating 
        //tables 
        public DataContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfig  = new AppConfiguration(); 
            var OptionsBuilder = new DbContextOptionsBuilder<DataContext>(); 
            OptionsBuilder.UseSqlServer(appConfig.SqlConnectionString); 
            return new DataContext(OptionsBuilder.Options ); 
        }
    }
}