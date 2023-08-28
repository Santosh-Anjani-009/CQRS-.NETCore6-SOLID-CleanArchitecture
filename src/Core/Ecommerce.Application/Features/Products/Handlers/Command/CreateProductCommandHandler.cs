using Ecommerce.Application.DTOs.EntitiesDto.Product.Validators;
using Ecommerce.Application.Features.Products.Requests.Command;
using Ecommerce.Application.Models.Email;
using Ecommerce.Application.Persistance.Contracts;
using Ecommerce.Application.Persistance.Email;
using Ecommerce.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Handlers.Command
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper, IEmailSender emailSender)
        {
            _repository = repository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // validator
            var response = new BaseCommandResponse();
            var validator = new ProductValidator(_repository);
            var validatorResult = await validator.ValidateAsync(request.productDto, cancellationToken);
            if (!validatorResult.IsValid)
            {
                response.Success = false;
                response.Message = "creation fails";
                response.Errors = validatorResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Exception();
            }

            var product = _mapper.Map<Product>(request.productDto);
            await _repository.CreateAsync(product);
            response.Success = true;
            response.Message = $"Successfull added product {request.productDto.Name}";
            response.Id = request.productDto.Id;


            // send email regrading new product
            try
            {
                var email = new EmailMessage()
                {
                    To = "customer@gmail.com",
                    Subject = "sent email successfully",
                    Body = "uploading new product"
                };

                await _emailSender.SendEmailAsync(email);

            }catch (Exception)
            {
                throw;
            }

            return response;
        }
    }
}
