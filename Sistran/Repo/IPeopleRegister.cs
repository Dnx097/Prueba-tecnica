using Sistran.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaSistran.Servicios.Services
{
    /// <summary>
    /// Interfaz que define las operaciones CRUD para el modelo Persona.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// Inserta un nuevo registro de Persona.
        /// </summary>
        /// <param name="persona">El modelo Persona a insertar.</param>
        /// <returns>True si la inserción es exitosa, de lo contrario false.</returns>
        Task<bool> InsertAsync(Persona persona);

        /// <summary>
        /// Actualiza un registro existente de Persona.
        /// </summary>
        /// <param name="persona">El modelo Persona con los datos actualizados.</param>
        /// <returns>True si la actualización es exitosa, de lo contrario false.</returns>
        Task<bool> UpdateAsync(Persona persona);

        /// <summary>
        /// Elimina un registro de Persona por su ID.
        /// </summary>
        /// <param name="id">El ID del registro a eliminar.</param>
        /// <returns>True si la eliminación es exitosa, de lo contrario false.</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Obtiene un registro de Persona por su ID.
        /// </summary>
        /// <param name="id">El ID del registro a obtener.</param>
        /// <returns>El modelo Persona con el ID especificado.</returns>
        Task<Persona> GetByIdAsync(int id);

        /// <summary>
        /// Obtiene un registro de Persona por su número de identificación.
        /// </summary>
        /// <param name="identificationNumber">El número de identificación del registro a obtener.</param>
        /// <returns>El modelo Persona con el número de identificación especificado.</returns>
        Task<Persona> GetByIdentificationNumberAsync(int identificationNumber);

        /// <summary>
        /// Obtiene todos los registros de Persona.
        /// </summary>
        /// <returns>Una lista de modelos Persona.</returns>
        Task<List<Persona>> GetAllAsync();
    }
}
