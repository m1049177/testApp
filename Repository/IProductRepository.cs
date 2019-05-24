using testApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.Repository
{
    public interface IProductRepository 
    {
        Task<List<Products>> GetProductList();
        void PostProductList(Products products);
    }
}
