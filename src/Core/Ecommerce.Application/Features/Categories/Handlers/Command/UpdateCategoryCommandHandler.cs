using Ecommerce.Application.Features.Categories.Requests.Command;
using Ecommerce.Application.Persistance.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Categories.Handlers.Command
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var oldCategory = await _repository.GetAsync(request.categoryDto.Id);
            var response = _mapper.Map(request.categoryDto, oldCategory);

            await _repository.UpdateAsync(response);

            return Unit.Value;
        }
    }
}
