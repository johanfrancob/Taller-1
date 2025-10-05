using Management.Backend.Repositories.Implementations;
using Management.Backend.Repositories.Interfaces;
using Management.Backend.UnitsOfWork.Interfaces;
using Management.Shared.DTOs;
using Management.Shared.Entities;
using Management.Shared.Responses;

namespace Management.Backend.UnitsOfWork.Implementations
{
	public class EmployeesUnitOfWork: GenericUnitOfWork<Employee>, IEmployeesUnitOfWork
	{
		private readonly IEmployeesRepository _employeesRepository;

		public EmployeesUnitOfWork(IGenericRepository<Employee> repository, IEmployeesRepository employeesRepository ) : base(repository)
		{
			_employeesRepository = employeesRepository;
		}
		public async Task<ActionResponse<IEnumerable<Employee>>> SearchAsync(string text) => await _employeesRepository.SearchAsync(text);
		public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination) => await _employeesRepository.GetAsync(pagination);
		public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await _employeesRepository.GetTotalRecordsAsync(pagination);

	}
}
