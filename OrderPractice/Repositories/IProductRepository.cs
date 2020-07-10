using OrderPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrderPractice.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> Find(Expression<Func<Product, bool>> predicate);
    }
}
