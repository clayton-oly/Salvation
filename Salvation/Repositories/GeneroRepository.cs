using Microsoft.EntityFrameworkCore;
using Salvation.Data;
using Salvation.Interfaces;
using Salvation.Models;

namespace Salvation.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly SalvationDbContext _context;
        public GeneroRepository(SalvationDbContext context)
        {
            _context = context;
        }

        //implementar somente este metodo
        public async Task<List<Genero>> GetAllAsync()
        {
            return await _context.Generos.ToListAsync();
        }

        //stand by
        public Task AddAsync(Genero genero)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Genero> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Genero genero)
        {
            throw new NotImplementedException();
        }
    }
}
