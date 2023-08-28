using Ecommerce.Application.DTOs.EntitiesDto.Product.Validators;
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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new ProductValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request.productDto, cancellationToken);
            if (!validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult);
            }

            var oldProduct = await _repository.GetAsync(request.productDto.Id);
            var response = _mapper.Map(request.productDto, oldProduct);
            await _repository.UpdateAsync(response);

            return Unit.Value;
        }
    }
}
