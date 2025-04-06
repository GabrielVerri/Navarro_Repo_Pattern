using Navarro_Repo_pattern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Navarro_Repo_pattern.Domain;

namespace Navarro_Repo_Pattern.Infra
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ECommerceDb01;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da tabela Usuario (relação muitos-para-muitos com Seguidores)
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Seguidores)
                .WithMany();
            //Este código configura um relacionamento "muitos para muitos" entre usuários, onde um usuário pode ter muitos seguidores e um usuário pode ser seguido por muitos outros usuários.
            //O WithMany() sem argumentos indica que o EF Core deve usar as convenções padrão para criar a tabela de junção necessária para este relacionamento.

            // Configuração da Postagem (relação um-para-muitos com Autor)
            modelBuilder.Entity<Postagem>()
                .HasOne(p => p.Autor)
                .WithMany()
        .HasForeignKey(p => p.AutorId);
            //Uma postagem pode ter somente 1 Autor, mas 1 Autor pode fazer várias postagens

            // Configuração da relação Postagem-Curtidas (muitos-para-muitos)
            modelBuilder.Entity<Postagem>()
                .HasMany(p => p.Curtidas)  // Postagens têm várias curtidas (relacionamento com "Usuario")
                .WithMany(u => u.Curtidas) // Usuários podem curtir várias postagens
                .UsingEntity<Dictionary<string, object>>(
                    "PostagemCurtidas",
                    j => j
                        .HasOne<Usuario>()
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict), // **Remove o cascata na deleção do usuário**
                    j => j
                        .HasOne<Postagem>()
                        .WithMany()
                        .HasForeignKey("PostagemId")
                        .OnDelete(DeleteBehavior.Cascade) // **Deixa a deleção em cascata na postagem**
                );
            modelBuilder.Entity<Postagem>()
                .HasMany(u => u.Comentarios)
                .WithMany();
            //Este código configura um relacionamento "muitos para muitos" entre Postagem e Usuario,
            //representando o fato de que postagens podem ser curtidas por muitos usuários, e usuários
            //podem curtir muitas postagens.

            // Configuração da relação Evento-Participantes (muitos-para-muitos)
            //modelBuilder.Entity<Evento>()
            //    .HasMany(e => e.Participantes)
            //    .WithMany();
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<Evento> Eventos { get; set; }
    }
}





