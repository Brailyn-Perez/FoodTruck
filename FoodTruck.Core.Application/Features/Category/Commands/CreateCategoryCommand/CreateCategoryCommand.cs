using AutoMapper;
using FoodTruck.Core.Application.Interfaces.Persistence;
using FoodTruck.Core.Application.Wrappers;
using MediatR;

namespace FoodTruck.Core.Application.Features.Category.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }

    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Response<int>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newRecord = _mapper.Map<Domain.Entities.Category>(request);
            return new Response<int>(await _repository.AddAsync(newRecord));
        }
    }
}
