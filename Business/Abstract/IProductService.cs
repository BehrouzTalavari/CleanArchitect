using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int productId);
        List<Product> GetList();
        List<Product> GetListByUnitId(int unitId);
        Product Add(Product product);
        Product Update(Product product);
        void Delete(Product product);
    }
}
