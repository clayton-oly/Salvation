using Microsoft.EntityFrameworkCore;
using Salvation.Data;
using Salvation.Interfaces;
using Salvation.Models;

namespace Salvation.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SalvationDbContext _context;
        public UsuarioRepository(SalvationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.Include(u => u.TipoUsuario).ToListAsync();
        }

        public async Task<List<Usuario>> GetAllAtivosAsync()
        {
            return await _context.Usuarios.Where(u => u.Ativo).Include(u => u.TipoUsuario).ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.Include(u => u.TipoUsuario).FirstOrDefaultAsync(u => u.IdUsuario == id);
        }

        public async Task InativarAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null && usuario.Ativo)
            {
                usuario.Ativo = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task ReativarAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null && !usuario.Ativo)
            {
                usuario.Ativo = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> ValidarLoginAsync(string email, string senha)
        {
            return await _context.Usuarios.Include(u => u.TipoUsuario)
                                          .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }
    }
}
