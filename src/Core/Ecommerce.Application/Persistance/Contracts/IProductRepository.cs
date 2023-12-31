﻿
namespace Ecommerce.Application.Persistance.Contracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetAllAsyncWithInclude();
    }
}
