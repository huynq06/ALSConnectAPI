using AlsConnect.Data.EF.Entities;
using AlsConnect.Data.EF.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Data.EF.Repositories
{
    public class ProductRepository : EFRepository<Product, int>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
