using Microsoft.EntityFrameworkCore;
using DebraAPI.Model;
namespace DebraAPI.Data
{
    public class DebraAddDBContext : DbContext
    {
        public DebraAddDBContext(DbContextOptions<DebraAddDBContext> options) : base(options)
        {

        }
        //For each model class need to do as give below
        public DbSet<Partner> Partners { get; set; }
        public DbSet<CreateEvent> CreateEvents { get; set; }
         
        public DbSet<SelTicket> SelTickets {  get; set; }

        public DbSet<DebraAdmin> DebraAdmins {  get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Partner>();
            modelBuilder.Entity<CreateEvent>();
            modelBuilder.Entity<SelTicket>();
            modelBuilder.Entity<DebraAdmin>();
            
       




        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //con is yhe connection string
            //Make sure your connection string has TrustServerCertificate


            var conn = @"Data Source=DESKTOP-PSG981M\KAVINDASQL;User ID=sa;Password=1234;Connect Timeout=30;Encrypt=False;
Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(conn);
        }

    }
}
