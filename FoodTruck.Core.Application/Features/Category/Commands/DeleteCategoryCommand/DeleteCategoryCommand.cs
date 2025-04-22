using FoodTruck.Core.Application.Exceptions;
using FoodTruck.Core.Application.Interfaces.Persistence;
using FoodTruck.Core.Application.Wrappers;
using MediatR;

namespace FoodTruck.Core.Application.Features.Category.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Response<int>>
    {
        private readonly ICategoryRepository _repository;

        public DeleteCategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<int>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            if (category == null)
            {
                throw new ApiException("Category Not Found");
            }

            return new Response<int>(await _repository.DeleteAsync(category));
        }
    }
}
