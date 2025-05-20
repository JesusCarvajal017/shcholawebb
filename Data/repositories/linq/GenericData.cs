
using Data.interfaces.global;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.repositories.linq
{
    public abstract class GenericData<T> : CrudGeneric<T> where T : class
    {
        private readonly AplicationDbContext _context;
        private readonly ILogger<T> _logger;

        public GenericData(AplicationDbContext context, ILogger<T> logger)
        { 
            _context = context;
            _logger = logger;   
        }

        /// <summary>
        /// Consulta a toda una entidad
        /// </summary>
        /// <param name="a">Primer número</param>
        /// <returns>La suma de a y b</returns>
        public virtual async Task<IEnumerable<T>> QueryAllAsyn()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, "No se pudeo obtner la entidad");
                throw;
            }
        }


        // SELECT BY ID
        public virtual async Task<T?> QueryById(int id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al traer una Forma por id {id}");
                throw;
            }
        }

        // INSERT 
        public virtual async Task<T> InsertAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"no se pudo agregar Forma {entity}");
                throw;
            }
        }

        // UPDATE
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"No se pudo actualizar {entity}");
                throw;

            }
        }

        // DELETE PERSISTENT
        public virtual async Task<Object> DeleteAsync(int id)
        {
            try
            {
                var Delete = await QueryById(id);

                if (Delete == null) return new { status = false }; // usuario inexistente

                _context.Set<T>().Remove(Delete);
                await _context.SaveChangesAsync();
                return new { status = true };
            }
            catch (Exception ex)
            {
                _logger.LogInformation($" error al eliminar {ex.Message}");
                return false;
            }
        }

        // DELETE LOGICAL
        public virtual async Task<object> DeleteLogicalAsyn(int id, T Entry)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null)
                    return new { status = false, message = "Registro no encontrado" };

                var properties = typeof(T).GetProperties(); // todas las propiedades del objeto T

                foreach (var prop in properties)
                {
                    var newValue = prop.GetValue(Entry);

                    // Verifica si el valor es diferente de null (y distinto de default en structs)
                    if (newValue != null && !Equals(newValue, GetDefault(prop.PropertyType)))
                    {
                        prop.SetValue(entity, newValue);
                        _context.Entry(entity).Property(prop.Name).IsModified = true;
                    }
                }

                await _context.SaveChangesAsync();
                return new { status = true };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al hacer patch dinámico a {typeof(T).Name}");
                return new { status = false, message = "Error interno" };
            }
        }

        private object? GetDefault(Type type) =>
            type.IsValueType ? Activator.CreateInstance(type) : null;
    }
}
