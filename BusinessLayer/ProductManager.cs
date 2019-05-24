using testApp.Models;
using testApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.BusinessLayer
{
 public class ProductManager : IProductManager
    {
        public readonly IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<List<Products>> GetProductList()
        {
            try
            {
                return (_productRepository.GetProductList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async void PostProductList(Products products)
        {
            try
            {
                _productRepository.PostProductList(products);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
