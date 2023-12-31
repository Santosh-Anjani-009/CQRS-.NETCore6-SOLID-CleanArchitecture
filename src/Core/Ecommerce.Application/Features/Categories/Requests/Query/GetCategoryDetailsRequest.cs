﻿using Ecommerce.Application.DTOs.EntitiesDto.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Features.Categories.Requests.Query
{
    public class GetCategoryDetailsRequest: IRequest<CategoryDto>   
    {
        public int Id { get; set; }

    }
}
