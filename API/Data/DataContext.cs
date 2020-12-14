using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserInfo> UserInfo {get;set;}
        public DbSet<GrantProgram> GrantProgram {get;set;}
    }
}