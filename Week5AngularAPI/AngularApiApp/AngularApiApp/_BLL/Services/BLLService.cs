using AngularApiApp._BLL.Models;
using AngularApiApp._DAL.Models;
using AngularApiApp._DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApiApp._BLL.Services
{
    public interface BLLServiceInterface
    {
        ProductBLLModel GetProduct(int productId);
        List<ProductBLLModel> GetAllProducts();
        void AddProduct(ProductBLLModel product);
        void UpdateProduct(ProductBLLModel product);
        void DeleteProduct(int productId);

        CategoryBLLModel GetCategory(int categoryId);
        List<CategoryBLLModel> GetAllCategorys();
        void AddCategory(CategoryBLLModel category);
        void UpdateCategory(CategoryBLLModel category);
        void DeleteCategory(int categoryId);
    }

    public class BLLService : BLLServiceInterface
    {
        private readonly DALServiceInterface _dataService;

        public BLLService(DALServiceInterface dataService)
        {
            _dataService = dataService;
        }

        public void AddCategory(CategoryBLLModel category)
        {
            _dataService.AddCategory(category);
        }

        public void AddProduct(ProductBLLModel product)
        {
            _dataService.AddProduct(product);
        }

        public void DeleteCategory(int categoryId)
        {
            _dataService.DeleteCategory(categoryId);
        }

        public void DeleteProduct(int productId)
        {
            _dataService.DeleteProduct(productId);
        }

        public List<CategoryBLLModel> GetAllCategorys()
        {
            return _dataService.GetAllCategorys();
        }

        public List<ProductBLLModel> GetAllProducts()
        {
            return _dataService.GetAllProducts();
        }

        public CategoryBLLModel GetCategory(int categoryId)
        {
            return _dataService.GetCategory(categoryId);
        }

        public ProductBLLModel GetProduct(int productId)
        {
            return _dataService.GetProduct(productId);
        }

        public void UpdateCategory(CategoryBLLModel category)
        {
            _dataService.UpdateCategory(category);
        }

        public void UpdateProduct(ProductBLLModel product)
        {
            _dataService.UpdateProduct(product);
        }
    }
}
