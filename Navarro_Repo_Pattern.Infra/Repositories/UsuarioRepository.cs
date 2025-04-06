using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navarro_Repo_Pattern.Infra.Interface;
using Navarro_Repo_pattern.Domain;
using Microsoft.EntityFrameworkCore;

namespace Navarro_Repo_Pattern.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private MySQLContext _context;
        public UsuarioRepository(MySQLContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {//TODO checar se esta trazneod o curso
            var usuarios = await _context.Usuarios.Include(u => u.Seguidores).ToListAsync();
            if (usuarios == null) return null;
            return usuarios;
        }
        public async Task<Usuario> GetUsuariosByIdAsync(Guid id)
        {
            return await
                _context.Usuarios.Include( u => u.Seguidores)
                    .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task AddUsuarioAsync(Usuario usuario,Guid curso)
        {
            _context.Cursos.FirstOrDefaultAsync(c => c.Id == curso);
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            
        }
        public async Task DeleteUsuarioAsync(Guid id)
        {
            var usuario = await GetUsuariosByIdAsync(id);
            if (usuario == null) return ;
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            
        }

        public async Task SeguirUsuarioAsync(Guid id_seguido, Guid id_seguidor)
        {
            var usuario_seguido = await GetUsuariosByIdAsync(id_seguido);
            if (usuario_seguido == null) return;
            var usuario_seguidor = await GetUsuariosByIdAsync(id_seguidor);
            if (usuario_seguidor == null) return;
            usuario_seguido.Seguidores.Add(usuario_seguidor);

            await _context.SaveChangesAsync();
        }
        public async Task PararSeguirUsuarioAsync(Guid id_seguido, Guid id_seguidor)
        {
            var usuario_seguido = await GetUsuariosByIdAsync(id_seguido);
            if (usuario_seguido == null) return;
            var usuario_seguidor = await GetUsuariosByIdAsync(id_seguidor);
            if (usuario_seguidor == null) return;
            usuario_seguido.Seguidores.Remove(usuario_seguidor);

            await _context.SaveChangesAsync();

        }

    }
}
