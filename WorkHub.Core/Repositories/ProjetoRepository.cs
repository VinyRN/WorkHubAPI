using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHub.Domain;
using WorkHub.Infrastructure;

namespace WorkHub.Core.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly AppDbContext _context;

        public ProjetoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Projeto>> GetAllByUsuarioIdAsync(int usuarioId)
        {
            return await _context.Set<Projeto>().Where(p => p.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task<Projeto> GetByIdAsync(int projetoId)
        {
            return await _context.Set<Projeto>().FirstOrDefaultAsync(p => p.ProjetoId == projetoId);
        }

        public async Task AddAsync(Projeto projeto)
        {
            await _context.Set<Projeto>().AddAsync(projeto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Projeto projeto)
        {
            _context.Set<Projeto>().Update(projeto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Projeto projeto)
        {
            _context.Set<Projeto>().Remove(projeto);
            await _context.SaveChangesAsync();
        }
    }
}
