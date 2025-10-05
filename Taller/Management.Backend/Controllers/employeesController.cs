using Management.Backend.UnitsOfWork.Interfaces;
using Management.Shared.DTOs;
using Management.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Management.Backend.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class EmployeesController : GenericController<Employee>
	{
		private readonly IEmployeesUnitOfWork _employeesUnitOfWork;
		public EmployeesController(IGenericUnitOfWork<Employee> unitOfWork, IEmployeesUnitOfWork employeesUnitOfWork) : base(unitOfWork)
		{
			_employeesUnitOfWork = employeesUnitOfWork;
		}


		[HttpGet("search/{text}")]
		public virtual async Task<IActionResult> SearchAsync(string text)
		{
			var action = await _employeesUnitOfWork.SearchAsync(text);
			if (!action.WasSuccess)
			{
				return BadRequest(action.Message);
			}
			return Ok(action.Result);
		}

		[HttpGet("paginated")]
		public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
		{
			var response = await _employeesUnitOfWork.GetAsync(pagination);
			if (response.WasSuccess)
			{
				return Ok(response.Result);
			}
			return BadRequest();
		}

		[HttpGet("totalRecords")]
		public override async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
		{
			var action = await _employeesUnitOfWork.GetTotalRecordsAsync(pagination);
			if (action.WasSuccess)
			{
				return Ok(action.Result);
			}
			return BadRequest();
		}

	}
}
