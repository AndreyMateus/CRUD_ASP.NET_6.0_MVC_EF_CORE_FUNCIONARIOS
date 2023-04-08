using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Database;

// Classe de configuração com o banco
// Esse processo é o mesmo independente do banco que você esteja usando.
// Não se esqueça de importar a Biblioteca de código do Entity Framework Core
public class ApplicationDBContext : DbContext
{
    // Dizendo para o DbContext que eu quero MAPEAR a minha ENTIDADE Funcionário no meu Banco de Dados, ele só mapeará as classes/entidades que você especificar/dizer a ele.
    // OBS: o NOME da propriedade é geralmente o nome da entidade no plural.
    public DbSet<Funcionario> Funcionarios {get; set;}

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }
}