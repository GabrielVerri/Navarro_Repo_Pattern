using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Navarro_Repo_pattern.Domain;

namespace Navarro_Repo_Pattern.Infra.Interface
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> GetAllCursosAsync();
        Task<Curso> GetCursoByIdAsync(Guid id);
        Task AddCursoAsync(Curso curso);
        Task UpdateCursoAsync(Curso curso);
        Task DeleteCursoAsync(Guid id);
    }
}
