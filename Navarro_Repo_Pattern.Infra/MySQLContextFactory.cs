using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Navarro_Repo_Pattern.Infra;

namespace DDDCommerceComRepository.Infra.RedeSocial
{
    public class SqlContextFactory : IDesignTimeDbContextFactory<MySQLContext>
    {
        public MySQLContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MySQLContext>();

            // Usa a string de conexão diretamente, igual ao OnConfiguring()
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ECommerceDb01;TrustServerCertificate=True");

            return new MySQLContext(optionsBuilder.Options);
        }
    }

}
