using Business.Abstract;
using Core.Utility.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    internal class ProductManager : IProductService
    {
        private readonly IProductDAL _productDAL;

        public ProductManager(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public IDataResult<Product> Add(Product product)
        {
            return new SuccessDataResult<Product>(product);
        }

        public IResult Delete(Product product)
        {
            _productDAL.Delete(product);
            return new SuccessResult("Product Is Deleted.");
        }

        public IDataResult<Product> GetById(int productId)
        {
            var result = _productDAL.GetList().FirstOrDefault(x => x.Id == productId);
            return new SuccessDataResult<Product>(result);
        }

        public IDataResult<List<Product>> GetList()
        {
            var result = _productDAL.GetList().ToList();
            return new SuccessDataResult<List<Product>>(result);
        }

        public IDataResult<List<Product>> GetListByUnitId(int unitId)
        {
            var result = _productDAL.GetList().Where(x => x.UnitId == unitId).ToList();
            return new SuccessDataResult<List<Product>>(result);

        }

        public IResult Update(Product product)
        {
            _productDAL.Update(product);
            return new SuccessResult("Product Is Updated.");
        }
    }
}
