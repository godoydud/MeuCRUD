using MeuCRUD.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace MeuCRUD.Models.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> option) : base(option) // Construtor
        {
            Database.EnsureCreated(); // Verifica se o banco existe, caso não exista ele mapeia a entidade e cria as tabelas
        }

        public DbSet<Usuario> Usuario { get; set; }

    }
}
