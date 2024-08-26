using SISTRAN.CAD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaSistran.Servicios.Services
{
    public interface IPeopleRegister
    {
        Task<bool> Insert(Persona model);
        Task<bool> Update(Persona model);
        Task<bool> Delete(int id);
        Task<Persona> GetById(int id);
        Task<Persona> GetByIdentification(int identification);
        Task<List<Persona>> GetAll();
    }
}
