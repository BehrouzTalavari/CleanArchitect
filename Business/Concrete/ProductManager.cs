﻿using Business.Abstract;
using Business.Constants;

using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Performance;
using Core.Aspect.Autofac.Transaction;
using Core.Utility.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
            _productDAL.Add(product); 
            return new SuccessDataResult<Product>(product);
        }

        public IResult Delete(Product product)
        {
            _productDAL.Delete(product);
            return new SuccessResult(Messages.ProductRemoved);
        }

        public IDataResult<Product> GetById(int productId)
        {
            var result = _productDAL.GetList().FirstOrDefault(x => x.Id == productId);
            return new SuccessDataResult<Product>(result);
        }
        [CacheAspect(1)]
        [PerformanceAspect(1)]
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
        [TransactionScopeAspect]
        public IResult Update(Product product)
        {
            _productDAL.Update(product); 
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
