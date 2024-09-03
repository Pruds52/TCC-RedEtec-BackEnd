using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using RedEtecAPI.Data;
using RedEtecAPI.Entities;

namespace RedEtecAPI.Services
{
    public class ProfessorService
    {
        private readonly RedEtecAPIContext _context;

        public ProfessorService(RedEtecAPIContext context)
        {
            _context = context;
        }

        public async Task<List<Professor>> GetAllAsync()
        {
            return await _context.Professor.ToListAsync();
        }

        public async Task<Professor> GetByIdAsync(int id)
        {
            return await _context.Professor.FindAsync(id);
        }

        public async Task CreateAsync(Professor professor)
        {
            _context.Add(professor);

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Professor professor)
        {
            _context.Entry(professor).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Professor professor)
        {
            _context.Remove(professor);

            await _context.SaveChangesAsync();
        }
    }
}
