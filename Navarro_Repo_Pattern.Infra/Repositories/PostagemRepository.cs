using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Navarro_Repo_pattern.Domain;
using Navarro_Repo_Pattern.Infra.Interface;

namespace Navarro_Repo_Pattern.Infra.Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        private MySQLContext _context;
        public PostagemRepository(MySQLContext context)
        {
            _context = context;
        }
        public async Task AddPostagemAsync(Postagem postagem)
        {
            await _context.Postagens.AddAsync(postagem);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePostagemAsync(Guid id)
        {
            var postagem = GetPostagemByIdAsync(id);
            if (postagem == null) return;
            _context.Postagens.Remove(postagem.Result);
             _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Postagem>> GetAllPostagensUsuarioAsync(Guid usuario)
        {
            var postagens = await _context.Postagens.Where(p => p.Autor.Id == usuario).ToListAsync();
            if (postagens == null) return null ;
            return postagens;
        }
        public async Task<Postagem> GetPostagemByIdAsync(Guid id)
        {
            return await _context.Postagens.Include(p => p.Autor)
                                           .Include(p => p.Curtidas)
                                           .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task UpdatePostagemAsync(Postagem postagem)
        {
            _context.Postagens.Update(postagem);
            await _context.SaveChangesAsync();
        }
        public async Task AddComentarioAsync(Guid postagemId,Postagem comentario)
        {
            var postagem = await GetPostagemByIdAsync(postagemId);
            if (postagem != null)
            {
                postagem.Comentarios ??= new List<Postagem>();
                postagem.Comentarios.Add(comentario);
                await _context.SaveChangesAsync();
            }
        }
        public async Task AddCurtidaAsync(Guid postagemId, Guid usuarioId)
        {
            var postagem = await GetPostagemByIdAsync(postagemId);
            var usuario = await _context.Usuarios.FindAsync(usuarioId);

            if (postagem != null && usuario != null)
            {
                postagem.Curtidas ??= new List<Usuario>();
                postagem.Curtidas.Add(usuario);
                await _context.SaveChangesAsync();
            }
        }

    }
}
