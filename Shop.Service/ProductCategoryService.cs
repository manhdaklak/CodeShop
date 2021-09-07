using Shop.Data.Repositories;
using Shop.Data.Structure;
using Shop.Model.Models;
using System;
using System.Collections.Generic;

namespace Shop.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory productCategory);

        ProductCategory DeleteById(int Id);

        void Update(ProductCategory productCategory);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAll(string keywork);

        IEnumerable<ProductCategory> GetParentById(int parentId);

        ProductCategory GetById(int Id);

        void Save();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitWork _unitWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IUnitWork unitWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitWork = unitWork;
        }

        public ProductCategory Add(ProductCategory productCategory)
        {
            return _productCategoryRepository.Add(productCategory);
        }

        public ProductCategory DeleteById(int Id)
        {
            return _productCategoryRepository.DeleteByID(Id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }

        public IEnumerable<ProductCategory> GetAll(string keywork)
        {
            if (!string.IsNullOrEmpty(keywork))
                return _productCategoryRepository.GetMulti(x => x.Name.Contains(keywork));
            else
                return _productCategoryRepository.GetAll();
        }

        public ProductCategory GetById(int Id)
        {
            return _productCategoryRepository.GetSingleById(Id);
        }

        public IEnumerable<ProductCategory> GetParentById(int parentId)
        {
            return _productCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public void Save()
        {
            _unitWork.Commit();
        }

        public void Update(ProductCategory productCategory)
        {
            throw new NotImplementedException();
        }
    }
}