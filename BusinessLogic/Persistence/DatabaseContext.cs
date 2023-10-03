using BusinessLogic.Domain.Aggregates;
using BusinessLogic.Persistence.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Persistence
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<FundAccount> FundAccounts { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<StudentHours> StudentHours { get; set; }
        public DbSet<BagFund> BagFund { get; set; }
        public DbSet<BagFundValue> BagFundValue { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BagFundValue>().HasNoKey();

            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            //modelBuilder.ApplyConfiguration(new BagFundValueConfig());
            modelBuilder.ApplyConfiguration(new FundAccountsConfig());
        }
    }
}
