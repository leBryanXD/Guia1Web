using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace Guia1.Models
{
    public class equiposContext: DbContext
    {
        public equiposContext(DbContextOptions<equiposContext>options): base(options) 
        {
        
        }
        public DbSet<carreras> carreras { get; set; }
    }
}
