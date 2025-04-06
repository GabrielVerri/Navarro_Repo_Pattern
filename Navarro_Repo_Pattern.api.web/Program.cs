// Add services to the container. DI (Dependency Injection)
using Navarro_Repo_Pattern.Infra;
using Navarro_Repo_Pattern.Infra.Interface;
using Navarro_Repo_Pattern.Infra.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<MySQLContext>();
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        builder.Services.AddScoped<ICursoRepository, CursoRepository>();
        builder.Services.AddScoped<IPostagemRepository, PostagemRepository>();
        //builder.Services.AddScoped<IEventoRepository, EventoRepository>();


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}