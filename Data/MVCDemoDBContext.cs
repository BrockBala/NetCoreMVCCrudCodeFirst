using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetCoreCrudCodefirst.Models;
using NetCoreCrudCodefirst.Models.Domain;

namespace NetCoreCrudCodefirst.Data
{
    public class MVCDemoDBContext : DbContext

    {
        public MVCDemoDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Fighter> Fighters { get; set; }
    }
}
