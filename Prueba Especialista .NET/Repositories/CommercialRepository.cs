using Prueba_Especialista_.NET.DbContexts;
using Prueba_Especialista_.NET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Prueba_Especialista_.NET.Repositories
{
    public class CommercialRepository : ICommercialRepository
    {
        private readonly VisitsDbContext _context;

        public CommercialRepository(VisitsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Commercial>> GetAllAsync()
        {
            return await _context.Commercials.ToListAsync();
        }

        public async Task<Commercial> GetByIdAsync(Guid id)
        {
            return await _context.Commercials.FindAsync(id);
        }

        public async Task AddAsync(Commercial commercial)
        {
            await _context.Commercials.AddAsync(commercial);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Commercial commercial)
        {
            _context.Commercials.Update(commercial);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var commercial = await _context.Commercials.FindAsync(id);
            if (commercial != null)
            {
                _context.Commercials.Remove(commercial);
                await _context.SaveChangesAsync();
            }
        }
    }

}
