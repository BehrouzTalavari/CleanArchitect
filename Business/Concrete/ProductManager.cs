using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;

using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Logging;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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

        [ValidationAspect(typeof(ProductValidator), Priority = 0)]
        [CacheRemoveAspect("IProductService.Get")]
        public IDataResult<Product> Add(Product product)
        {
            _productDAL.Add(product);
            return new SuccessDataResult<Product>(product);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Product product)
        {
            _productDAL.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
        [SecureOperation("admin")]
        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<Product> GetById(int productId)
        {
            var result = _productDAL.GetList().FirstOrDefault(x => x.Id == productId);
            return new SuccessDataResult<Product>(result);
        }
        [CacheAspect(1)]
        [PerformanceAspect(1)]
        public IDataResult<List<Product>> GetList()
        {
            throw new System.Exception("خطا");
            var result = _productDAL.GetList().ToList();
            return new SuccessDataResult<List<Product>>(result);
        }

        public IDataResult<List<Product>> GetListByUnitId(int unitId)
        {
            var result = _productDAL.GetList().Where(x => x.UnitId == unitId).ToList();
            return new SuccessDataResult<List<Product>>(result);

        }
        //[TransactionScopeAspect]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            _productDAL.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
