
using Ecommerce.Application.DTOs.EntitiesDto.Category;

namespace Ecommerce.Application.MappingProfiles
{
    public class CategoryMappingProfile: Profile
    {
        public CategoryMappingProfile()
        {
            // configure Automapper
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
