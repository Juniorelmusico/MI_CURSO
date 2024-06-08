using CRUDnet8MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDnet8MVC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones) : base(opciones)
        {
        }

        //Escribir modelos
        public DbSet<Producto> Producto { get; set; }
    }
}
