using Management.Backend.Data;
using Management.Backend.Repositories.Interfaces;
using Management.Shared.Entities;
using Management.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace Management.Backend.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entity; //representa una tabla de la base de datos

        public GenericRepository(DataContext context)
        {
            _context = context; //las privadas deben empezar con _
            _entity = context.Set<T>(); //Set es un método que devuelve la tabla de la base de datos que corresponde a la entidad T
        }

        public virtual async Task<ActionResponse<T>> AddAsync(T entity) //deben ser async para
        {
            _context.Add(entity);

            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>

                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();

            }
            catch (Exception ex)
            {
                return ExceptionActionResponse(ex);
            }
        }

        public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row == null)
            {
                return new ActionResponse<T>
                {
                    WasSuccess = false,
                    Message = "Registro no encontrado"
                };
            }

            try
            {
                _entity.Remove(row);
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                };
            }
            catch
            {
                return new ActionResponse<T>
                {
                    WasSuccess = false,
                    Message = "No se puede borrar porque tiene registros relacionados"
                };
            }

        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> SearchAsync(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new ActionResponse<IEnumerable<T>>
                {
                    WasSuccess = false,
                    Message = "Debe ingresar un criterio de búsqueda"
                };
            }

            if (typeof(T) == typeof(Employee))
            {
                var query = await _entity
                    .Cast<Employee>()
                    .Where(e => e.FirstName.Contains(text) || e.LastName.Contains(text))
                    .ToListAsync();

                if (query.Count() == 0)
                {
                    return new ActionResponse<IEnumerable<T>>
                    {
                        WasSuccess = false,
                        Message = "No se ha encontrado un resultado"
                    };
                }

                return new ActionResponse<IEnumerable<T>>
                {
                    WasSuccess = true,
                    Result = query.Cast<T>()
                };
            }

            return new ActionResponse<IEnumerable<T>>
            {
                WasSuccess = false,
                Message = "Ha ocurrido un error"
            };
        }




        public virtual async Task<ActionResponse<T>> GetAsync(int id)
        {
            var row = await _entity.FindAsync(id); //FindAsync busca por el id

            if (row == null)
            {
                return new ActionResponse<T>
                {
                    Message = "Registro no encontrado"
                };
            }
            return new ActionResponse<T> //si encuentra el registro lo devuelve
            {
                WasSuccess = true,
                Result = row
            };
        }


        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync() => new ActionResponse<IEnumerable<T>>
        {
            WasSuccess = true,
            Result = await _entity.ToListAsync()
        };


        public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
        {
            try
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception exception)
            {
                return ExceptionActionResponse(exception);
            }

        }
        private ActionResponse<T> ExceptionActionResponse(Exception ex) => new ActionResponse<T> //método para manejar la excepción general
        {
            Message = ex.Message
        };


        private ActionResponse<T> DbUpdateExceptionActionResponse() => new ActionResponse<T> //método para manejar la excepción de clave duplicada
        {
            Message = "Ya existe el registro"
        };
    }
}
