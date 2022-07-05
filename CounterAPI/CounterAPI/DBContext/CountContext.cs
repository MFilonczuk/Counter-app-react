using CounterAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CounterAPI.DBContext
{
    public class CountContext : DbContext
    {

        public DbSet<Count> Counts { get; set; } = null!;

        public CountContext(DbContextOptions<CountContext> options) : base (options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Count>().HasData(
        //        new Count { Id = 1, CountNumber = 1 },
        //        new Count { Id = 2, CountNumber = 2 },
        //        new Count { Id = 3, CountNumber = 3 }
        //    );
        //    base.OnModelCreating(modelBuilder);
        //}



    }
}
