using Ecommerce.Application.DTOs.Common;

namespace Ecommerce.Application.DTOs.EntitiesDto.Category
{
    public class CategoryDto : BaseDto<int>
    {
        public string Name { get; set; }
    }
}
