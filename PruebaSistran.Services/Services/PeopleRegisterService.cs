using Microsoft.EntityFrameworkCore;
using SISTRAN.CAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSistran.Servicios.Services
{
    public class PeopleRegisterService : IPeopleRegister
    {
        private readonly PruebaSistranContext _register;

        public PeopleRegisterService(PruebaSistranContext register)
        {
            _register = register;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var person = _register.Personas.Find(id);
                _register.Personas.Remove(person);
                await _register.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public async Task<List<Persona>> GetAll()
        {
            
            return await _register.Personas.ToListAsync();
        }

        public async Task<Persona> GetById(int id)
        {
            return await _register.Personas.FindAsync(id);           

        }

        public async Task<Persona> GetByIdentification(int id)
        {
            return await _register.Personas.FirstOrDefaultAsync(x => x.Identificacion == id);
        }

        public async Task<bool> Insert(Persona person)
        {
            try
            {
                var obj = await _register.AddAsync(person);

                _register.SaveChanges();


                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<bool> Update(Persona person)
        {
            try
            {
                _register.Update(person);
                await _register.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
