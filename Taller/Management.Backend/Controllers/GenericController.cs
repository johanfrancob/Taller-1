using Management.Backend.UnitsOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Management.Backend.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private readonly IGenericUnitOfWork<T> _unitOfWork;

        public GenericController(IGenericUnitOfWork<T> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAsync()
        {
            var action = await _unitOfWork.GetAsync();
            if (!action.WasSuccess)
            {
                return BadRequest(action.Message);
            }
            return Ok(action.Result);
        }

        [HttpGet("search/{text}")]
        public virtual async Task<IActionResult> SearchAsync(string text)
        {
            var action = await _unitOfWork.SearchAsync(text);
            if (!action.WasSuccess)
            {
                return BadRequest(action.Message);
            }
            return Ok(action.Result);
        }


        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetAsync(int id)
        {
            var action = await _unitOfWork.GetAsync(id);
            if (!action.WasSuccess)
            {
                return BadRequest(action.Message);
            }
            return Ok(action.Result);
        }



        [HttpPost]
        public virtual async Task<IActionResult> PostAsync(T model)
        {
            var action = await _unitOfWork.AddAsync(model);
            if (!action.WasSuccess)
            {
                return BadRequest(action.Message);
            }
            return Ok(action.Result);
        }

        [HttpPut]
        public virtual async Task<IActionResult> PutAsync(T model)
        {
            var action = await _unitOfWork.UpdateAsync(model);
            if (!action.WasSuccess)
            {
                return BadRequest(action.Message);
            }
            return Ok(action.Result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            var action = await _unitOfWork.DeleteAsync(id);
            if (!action.WasSuccess)
            {
                return BadRequest(action.Message);
            }
            return Ok(action.Result);
        }

    }
}
