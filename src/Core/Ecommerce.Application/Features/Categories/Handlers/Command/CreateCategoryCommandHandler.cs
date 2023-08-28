using Ecommerce.Application.DTOs.EntitiesDto.Category.Validators;
using Ecommerce.Application.Features.Categories.Requests.Command;
using Ecommerce.Application.Persistance.Contracts;
using Ecommerce.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Categories.Handlers.Command
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // check validator
            var response = new BaseCommandResponse();
            var validator = new CategoryValidator();
            var validatorResult = await validator.ValidateAsync(request.categoryDto);
            if (!validatorResult.IsValid)
            {
                response.Success = false;
                response.Message = "creation fails";
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Exception();
            }

            var category = _mapper.Map<Category>(request.categoryDto);
            await _repository.CreateAsync(category);
            response.Success = true;
            response.Message = "Creation successfull";
            response.Id = request.categoryDto.Id;

            return response;
        }
    }
}
