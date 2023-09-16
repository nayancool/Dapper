using Dapper.Application.Interfaces;

namespace Dapper.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository Products { get; }

        public UnitOfWork(IProductRepository productRepository)
        {
            Products = productRepository;
        }
    }
}