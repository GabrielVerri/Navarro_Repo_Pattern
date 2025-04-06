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
    internal class UsuarioRepositoy : IUsuarioRepository
    {
        private MySQLContext _context;
        public UsuarioRepositoy(MySQLContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuario> GetUsuariosById(Guid id)
        {

            return await
                _context.Usuarios.Include( u => u.Seguidores)
                    .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task AddUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUsuario(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            
        }
        public async Task DeleteUsuario(Guid id)
        {
            var usuario = await GetUsuariosById(id);
            if (usuario == null) return ;
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            
        }

    }
}
