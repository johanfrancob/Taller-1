using Microsoft.EntityFrameworkCore;
using Management.Backend.Data;
using Management.Backend.Helpers;
using Management.Backend.Repositories.Interfaces;
using Management.Shared.DTOs;
using Management.Shared.Entities;
using Management.Shared.Responses;

namespace Management.Backend.Repositories.Implementations;
public class StatesRepository : GenericRepository<State>, IStatesRepository
{
    private readonly DataContext _context;

    public StatesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<State>> GetComboAsync(int countryId)
    {
        return await _context.States
            .Where(s => s.CountryId == countryId)
            .OrderBy(s => s.Name)
            .ToListAsync();
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.States
            .Include(x => x.Cities)
            .Where(x => x.Country!.Id == pagination.Id)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x => x.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        return new ActionResponse<IEnumerable<State>>
        {
            WasSuccess = true,
            Result = await queryable
                .OrderBy(x => x.Name)
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public async Task<int> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var queryable = _context.States.AsQueryable();

  
        if (pagination.Id > 0) 
        {
            queryable = queryable.Where(x => x.CountryId == pagination.Id);
        }

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            queryable = queryable.Where(x =>
                x.Name.ToLower().Contains(pagination.Filter.ToLower()));
        }

        return await queryable.CountAsync();
    }


    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync()
    {
        var states = await _context.States
            .Include(s => s.Cities)
            .ToListAsync();
        return new ActionResponse<IEnumerable<State>>
        {
            WasSuccess = true,
            Result = states
        };
    }

    public override async Task<ActionResponse<State>> GetAsync(int id)
    {
        var state = await _context.States
             .Include(s => s.Cities)
             .FirstOrDefaultAsync(s => s.Id == id);

        if (state == null)
        {
            return new ActionResponse<State>
            {
                WasSuccess = false,
                Message = "Estado no existe"
            };
        }

        return new ActionResponse<State>
        {
            WasSuccess = true,
            Result = state
        };
    }
}