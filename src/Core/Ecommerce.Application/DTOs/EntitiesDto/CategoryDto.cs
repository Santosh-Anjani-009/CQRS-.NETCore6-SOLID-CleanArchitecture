
using Ecommerce.Application.DTOs.Common;

namespace Ecommerce.Application.DTOs.EntitiesDto
{
    public class CategoryDto: BaseDto<int>
    {
        public string Name { get; set; }
    }
}
