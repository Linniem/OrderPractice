using OrderPractice.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrderPractice.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> FindAsync(Expression<Func<Product, bool>> predicate);
    }
}
