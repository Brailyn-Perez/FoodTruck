using AutoMapper;
using FoodTruck.Core.Application.DTOs.Category;
using FoodTruck.Core.Application.Interfaces.Persistence;
using FoodTruck.Core.Application.Wrappers;
using MediatR;

namespace FoodTruck.Core.Application.Features.Category.Queries.GetAllCategory
{
    public class GetAllCategoryQuery : IRequest<Response<List<CategoryDTO>>>
    {
    }

    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, Response<List<CategoryDTO>>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryDTO>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var listRecords = await _repository.GetAllAsync();
            var Dtos = _mapper.Map<List<CategoryDTO>>(listRecords);
            return new Response<List<CategoryDTO>>(Dtos);
        }
    }
}
