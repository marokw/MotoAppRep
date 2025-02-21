namespace MotoApp.Data;

using Microsoft.EntityFrameworkCore;
using MotoApp.Data.Entities;
using System.Threading.Channels;

public class MotoAppDbContext : DbContext
{
    public MotoAppDbContext(DbContextOptions<MotoAppDbContext> options)
        :base(options)
    {
        
    }

    public DbSet<Car> Cars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //odkomentować gdy chcę sprawdzić info co dzieje się w trakcie uruchamiania zapytań
        //optionsBuilder.LogTo(Console.WriteLine);
    }


    //pozostałośc z nugeta Entity Framework Core InMemory
    /*    public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<BuisnessPartner> BuisnessPartnes => Set<BuisnessPartner>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }*/
}

