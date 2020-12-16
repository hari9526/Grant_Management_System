using data.Data;
using data.Model;
using Microsoft.EntityFrameworkCore;

namespace data.Data
{
    public class DataContext : DbContext
    {

        public class OptionBuild{
            public OptionBuild()
            {
                Settings = new AppConfiguration(); 
                OptionsBuilder = new DbContextOptionsBuilder<DataContext>(); 
                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString); 
                DbOptions = OptionsBuilder.Options;
                
            }
            //This allows to configure our conneciton to the database
            public DbContextOptionsBuilder<DataContext> OptionsBuilder{get;set;}
            //This allows us to obtain and hold on to database information 
            public DbContextOptions<DataContext> DbOptions{get;set;}
            //Connection string
            private AppConfiguration Settings {get;set;}


        }
        //To make OptionBuild available everywhere in the data project. 
        public static OptionBuild option = new OptionBuild(); 
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<UserInfo> UserInfo {get;set;}
        public DbSet<GrantProgram> GrantProgram {get;set;}
        public DbSet<ApplicantDetail> ApplicantDetails {get;set;}
        public DbSet<EducationDetail> EducationDetails {get;set;}
        public DbSet<UserGrantMapping> UserGrantMappings {get;set;}
        

    }
}