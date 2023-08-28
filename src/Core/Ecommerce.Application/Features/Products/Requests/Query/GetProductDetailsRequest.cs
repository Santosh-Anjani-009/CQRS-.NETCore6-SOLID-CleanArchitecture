using Ecommerce.Application.DTOs.EntitiesDto.Product;
using MediatR;


namespace Ecommerce.Application.Features.Products.Requests.Query
{
    public class GetProductDetailsRequest: IRequest<ProductDto>
    {
        public int Id { get; set; }
    }
}
