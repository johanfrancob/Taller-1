using Microsoft.EntityFrameworkCore;
using Management.Backend.Data;
using Management.Backend.Helpers;
using Management.Backend.Repositories.Interfaces;
using Management.Shared.DTOs;
using Management.Shared.Entities;
using Management.Shared.Responses;

namespace Management.Backend.Repositories.Implementations;

public class CitiesRepository : GenericRepository<City>, ICitiesRepository
{
    private readonly DataContext _context;

    public CitiesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<City>> GetComboAsync(int stateId)
    {
        return await _context.Cities
            .Where(c => c.StateId == stateId)
            .OrderBy(c => c.Name)
            .ToListAsync();
    }

    public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.Cities
            .Where(x => x.State!.Id == pagination.Id)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        return new ActionResponse<IEnumerable<City>>
        {
            WasSuccess = true,
            Result = await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var queryable = _context.Cities.AsQueryable();

        if (pagination.Id > 0)
        {
            queryable = queryable.Where(x => x.StateId == pagination.Id);
            
        }

      
        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            var filter = pagination.Filter.ToLower();
            queryable = queryable.Where(x => x.Name.ToLower().Contains(filter));
        }

        var count = await queryable.CountAsync();

        return new ActionResponse<int>
        {
            WasSuccess = true,
            Result = count 
        };
    }

}