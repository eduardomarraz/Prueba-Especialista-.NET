using Prueba_Especialista_.NET.DbContexts;
using Prueba_Especialista_.NET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba_Especialista_.NET.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private readonly VisitsDbContext _context;

        public VisitRepository(VisitsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Visit>> GetAllAsync()
        {
            return await _context.Visits
    .Include(v => v.Client)
    .Include(v => v.Commercial)
    .ToListAsync();
        }

        public async Task<Visit> GetByIdAsync(Guid id)
        {
            return await _context.Visits.FindAsync(id);
        }

        public async Task AddAsync(Visit visit)
        {
            await _context.Visits.AddAsync(visit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Visit visit)
        {
            _context.Visits.Update(visit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var visit = await _context.Visits.FindAsync(id);
            if (visit != null)
            {
                _context.Visits.Remove(visit);
                await _context.SaveChangesAsync();
            }
        }
    }

}