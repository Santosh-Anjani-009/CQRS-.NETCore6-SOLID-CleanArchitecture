using Ecommerce.Application.Exceptions;
using Ecommerce.Application.Features.Products.Requests.Command;
using Ecommerce.Application.Persistance.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Command
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository repository, IMapper mapper)

        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var oldProduct = await _repository.GetAsync(request.Id);
            if (oldProduct is null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            await _repository.DeleteAsync(oldProduct.Id);

            // return Unit.Value; if you make Task<Unit> then also why u are not able to return Unit.Value please check delete lectures like lecture 18
        }
    }
}
