using Core.Utility.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);
        IDataResult<List<Product>> GetList();
        IDataResult<List<Product>> GetListByUnitId(int unitId);
        IDataResult<Product> Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);
    }
}
