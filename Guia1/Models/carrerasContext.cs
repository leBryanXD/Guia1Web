using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace Guia1.Models
{
    public class carrerasContext: DbContext
    {
        public carrerasContext(DbContextOptions<carrerasContext>options): base(options) 
        {
        
        }
        public DbSet<carreras> carreras { get; set; }
    }
}
