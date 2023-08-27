

namespace Ecommerce.Application.DTOs.EntitiesDto
{
    public class ProductDto: BaseDto<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
