using AlsConnect.Application.ViewModels.Products;
using AlsConnect.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlsConnect.Application.Interfaces
{
    public interface IProductService : IDisposable
    {
        List<ProductViewModel> GetAll();
        PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize);
        ProductViewModel GetById(int id);
        ProductViewModel Add(ProductViewModel product);
        void Update(ProductViewModel product);
        void Delete(int id);
        void Save();
    }
}
