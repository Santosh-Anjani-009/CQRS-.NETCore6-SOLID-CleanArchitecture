
using MediatR;

namespace Ecommerce.Application.Features.Categories.Requests.Query
{
    public class GetAllCategoriesRequest: IRequest<List<CategoryDto>>
    {
    }
}
