using Ecommerce.Application.Features.Categories.Requests.Query;
using Ecommerce.Application.Persistance.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Categories.Handlers.Query
{
    public class GetCategoryDetailsRequestHandler : IRequestHandler<GetCategoryDetailsRequest, CategoryDto>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public GetCategoryDetailsRequestHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Handle(GetCategoryDetailsRequest request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetAsync(request.Id);

            if (category is null)
            {
                throw new Exception("Not found");
            }

            var response = _mapper.Map<CategoryDto>(category);

            return response;
        }
    }
}
