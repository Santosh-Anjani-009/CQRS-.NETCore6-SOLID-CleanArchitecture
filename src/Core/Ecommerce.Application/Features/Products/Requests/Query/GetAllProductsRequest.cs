
using Ecommerce.Application.DTOs.EntitiesDto.Product;
using MediatR;


namespace Ecommerce.Application.Features.Products.Requests.Query
{
    public class GetAllProductsRequest: IRequest<List<ProductDto>>
    {

    }
}
