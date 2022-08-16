using JsonWebTokenAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace JsonWebTokenAPI.Data
{
    public class DataContext : DbContext
    {

            public DataContext(DbContextOptions<DataContext> options)
                : base(options)
            {
            }

            public virtual DbSet<Isbike> Isbikes { get; set; }
            public virtual DbSet<User> Users { get; set; }

            
       }
}
