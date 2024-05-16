using FinancialApp.DataBase.DbModels;
using Microsoft.EntityFrameworkCore;

namespace FinServer.DbModels
{
    public class ApplicationContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FinServerDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public  DbSet<DbPerson> Persons { get; set; }

        public  DbSet<DbPersonMoney> PersonMoneys { get; set; }

        public  DbSet<DbHistoryTransfer> HistoryTransfers { get; set; }

        public  DbSet<DbAdmin> Admins { get; set; }

    }
}
