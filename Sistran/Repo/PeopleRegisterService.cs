using Microsoft.EntityFrameworkCore;
using Sistran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaSistran.Servicios.Services
{
    public class PersonService : IPersonService
    {
        private readonly PruebaSistranContext _context;

        public PersonService(PruebaSistranContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var person = await _context.Personas.FindAsync(id);
                if (person == null) return false;

                _context.Personas.Remove(person);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Log exception (e.g., using a logging framework)
                return false;
            }
        }

        public async Task<List<Persona>> GetAllAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona> GetByIdAsync(int id)
        {
            return await _context.Personas.Where(x => x.Identificacion == id).FirstAsync();
        }

        public async Task<Persona> GetByIdentificationNumberAsync(int identificationNumber)
        {
            return await _context.Personas.FirstOrDefaultAsync(x => x.Identificacion == identificationNumber);
        }

        public async Task<bool> InsertAsync(Persona person)
        {
            try
            {
                await _context.Personas.AddAsync(person);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Persona person)
        {
            try
            {
                _context.Personas.Update(person);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
