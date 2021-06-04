
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MediaBalansSaville.Data.DAL
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=saville.mssql.somee.com;Database=saville;User Id=saville_SQLLogin_1;Password=n3cd3ytml6;MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies().ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));
            return new ApplicationDbContext(optionsBuilder.Options);
        }
        
    }
} 