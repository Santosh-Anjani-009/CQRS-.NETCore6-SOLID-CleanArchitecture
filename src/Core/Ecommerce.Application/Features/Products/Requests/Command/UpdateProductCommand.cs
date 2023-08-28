using Ecommerce.Application.DTOs.EntitiesDto.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Products.Requests.Command
{
    public class UpdateProductCommand: IRequest<Unit>
    {
        public ProductDto productDto { get; set; }
    }
}
