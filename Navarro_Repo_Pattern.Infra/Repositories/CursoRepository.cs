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
    public class CursoRepository: ICursoRepository
    {
        private MySQLContext _context;
        public CursoRepository(MySQLContext context) 
        {
            _context=context;
        }
        public async Task AddCursoAsync(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();
        }
        public Task DeleteCursoAsync(Guid id)
        {
            var curso = GetCursoByIdAsync(id);
            if (curso == null) return Task.CompletedTask;
            _context.Cursos.Remove(curso.Result);
            return _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Curso>> GetAllCursosAsync()
        {
            var cursos = await _context.Cursos.ToListAsync();
            if (cursos == null) return null;
            return cursos;
        }
        public async Task<Curso> GetCursoByIdAsync(Guid id)
        {
            return await _context.Cursos.FirstOrDefaultAsync(c => c.Id == id);
        }
        public Task UpdateCursoAsync(Curso curso)
        {
            _context.Cursos.Update(curso);
            return _context.SaveChangesAsync();
        }
    

    }
}
