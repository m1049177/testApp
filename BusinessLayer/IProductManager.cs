using testApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testApp.BusinessLayer
{
    public interface IProductManager
    {
        Task<List<Products>> GetProductList();
        void PostProductList(Products product);
    }
}
