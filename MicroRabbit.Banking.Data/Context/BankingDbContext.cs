using MicroRabbit.Banking.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Banking.Data.Context
{
    public class BankingDbContext:DbContext
    {
        public BankingDbContext() : base()
        {
        }
        public BankingDbContext(DbContextOptions<BankingDbContext> options):base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(new SqlConnection(@"Server=REEM-AMR;Database=BankingDatabase;TrustServerCertificate=True;user id=sa;password=Dev@123456;"));
            //optionsBuilder.UseSqlServer(
            //    new SqlConnection(@"server=REEM-AMR;database=BankingDatabase;user id=sa;password='Dev@123456';"));

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Account> Accounts { get; set; }
    }
}
