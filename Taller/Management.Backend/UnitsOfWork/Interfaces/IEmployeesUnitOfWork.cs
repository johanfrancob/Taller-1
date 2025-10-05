using Management.Shared.DTOs;
using Management.Shared.Entities;
using Management.Shared.Responses;

namespace Management.Backend.UnitsOfWork.Interfaces
{
    public interface IEmployeesUnitOfWork
    {
        Task<ActionResponse<IEnumerable<Employee>>> SearchAsync(string text);
        Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination);
        Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

        Task<ActionResponse<IEnumerable<Employee>>> GetAsync();

        Task<ActionResponse<Employee>> GetAsync(int id);
    }
}
