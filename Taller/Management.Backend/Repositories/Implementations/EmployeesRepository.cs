using Management.Backend.Data;
using Management.Backend.Helpers;
using Management.Backend.Repositories.Interfaces;
using Management.Shared.DTOs;
using Management.Shared.Entities;
using Management.Shared.Responses;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Management.Backend.Repositories.Implementations
{
    public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
    {
        private readonly DataContext _context;
        public EmployeesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public virtual async Task<ActionResponse<IEnumerable<Employee>>> SearchAsync(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new ActionResponse<IEnumerable<Employee>>
                {
                    WasSuccess = false,
                    Message = "Debe ingresar un criterio de búsqueda"
                };
            }

            var query = await _context.Employees
            .Where(e =>
                e.FirstName.Contains(text) ||
                e.LastName.Contains(text))
            .OrderBy(e => e.FirstName)
            .ToListAsync();


            if (query.Count() == 0)
            {
                return new ActionResponse<IEnumerable<Employee>>
                {
                    WasSuccess = false,
                    Message = "No se ha encontrado un resultado"
                };
            }

            return new ActionResponse<IEnumerable<Employee>>
            {
                WasSuccess = true,
                Result = query.Cast<Employee>()
            };
        }

        public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _context.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                var f = pagination.Filter.ToLower();
                queryable = queryable.Where(x =>
                    x.FirstName.ToLower().Contains(f) ||
                    x.LastName.ToLower().Contains(f));
            }

            return new ActionResponse<IEnumerable<Employee>>
            {
                WasSuccess = true,
                Result = await queryable
                    .OrderBy(x => x.Id)
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
        {
            var queryable = _context.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                var f = pagination.Filter.ToLower();
                queryable = queryable.Where(x =>
                    x.FirstName.ToLower().Contains(f) ||
                    x.LastName.ToLower().Contains(f));
            }

            var total = await queryable.CountAsync();
            return new ActionResponse<int> { WasSuccess = true, Result = total };

        }

        public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync()
        {
            var states = await _context.Employees
                .ToListAsync();
            return new ActionResponse<IEnumerable<Employee>>
            {
                WasSuccess = true,
                Result = states
            };
        }


		public override async Task<ActionResponse<Employee>> GetAsync(int id)
		{
			var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
			return employee is null
				? new ActionResponse<Employee> { WasSuccess = false, Message = "No existe el empleado." }
				: new ActionResponse<Employee> { WasSuccess = true, Result = employee };
		}




	}
}


