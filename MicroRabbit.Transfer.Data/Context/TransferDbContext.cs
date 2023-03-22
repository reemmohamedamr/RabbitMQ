using MicroRabbit.Transfer.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {
        public TransferDbContext() : base()
        {
        }
        public TransferDbContext(DbContextOptions<TransferDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(new SqlConnection(@"Server=REEM-AMR;Database=TransferDatabase;TrustServerCertificate=True;user id=sa;password=Dev@123456;"));
           
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<TransferLog> TransferLogs { get; set; }
    }
}
