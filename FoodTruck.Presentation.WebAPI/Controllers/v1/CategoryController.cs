using FoodTruck.Core.Application.Features.Category.Commands.CreateCategoryCommand;
using FoodTruck.Core.Application.Features.Category.Commands.DeleteCategoryCommand;
using FoodTruck.Core.Application.Features.Category.Commands.UpdateCategoryCommand;
using FoodTruck.Core.Application.Features.Category.Queries.GetAllCategory;
using FoodTruck.Core.Application.Features.Category.Queries.GetCategoryById;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruck.Presentation.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class CategoryController : BaseApiController
    {
        #region Commands 
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCategoryCommand { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }
        #endregion

        #region queries
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCategoryQuery();
            return Ok(await Mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCategoryByIdQuery() { Id = id };
            return Ok(await Mediator.Send(query));
        }
        #endregion
    }
}
