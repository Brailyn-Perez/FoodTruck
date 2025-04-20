using AutoMapper;
using FoodTruck.Core.Application.DTOs.Category;
using FoodTruck.Core.Application.Interfaces.Persistence;
using FoodTruck.Core.Application.Wrappers;
using MediatR;

namespace FoodTruck.Core.Application.Features.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<Response<CategoryDTO>>
    {
        public int Id { get; set; }
    }

    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Response<CategoryDTO>>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<CategoryDTO>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var record = await _repository.GetByIdAsync(request.Id);

            if (record == null)
                throw new KeyNotFoundException("Category not found");

            var dto = _mapper.Map<CategoryDTO>(record);

            return new Response<CategoryDTO>(dto);
        }
    }
}
