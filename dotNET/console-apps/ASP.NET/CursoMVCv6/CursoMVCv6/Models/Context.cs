using Microsoft.EntityFrameworkCore;

namespace CursoMVCv6.Models
{
    public class Context : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //Método para configurar o Entity Framework
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Cursomvc;Integrated Security=True");
            //Definindo banco de dados
        }
    }
}
