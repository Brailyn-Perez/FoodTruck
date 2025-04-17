using FoodTruck.Core.Application.Features.User.Commands.CreateUserCommand;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruck.Presentation.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
