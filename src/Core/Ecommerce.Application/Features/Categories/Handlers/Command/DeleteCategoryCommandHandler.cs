using Ecommerce.Application.Features.Categories.Requests.Command;
using Ecommerce.Application.Persistance.Contracts;
using MediatR;

namespace Ecommerce.Application.Features.Categories.Handlers.Command
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // get category by id
            var oldCategory = await _repository.GetAsync(request.Id);

            // remove
            await _repository.DeleteAsync(oldCategory.Id);

        }
    }
}
