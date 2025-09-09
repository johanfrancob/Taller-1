using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Management.Shared.Entities;
using Management.Backend.UnitsOfWork.Interfaces;


namespace Management.Backend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class employeesController : GenericController<Employee>
    {
        public employeesController(IGenericUnitOfWork<Employee> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
