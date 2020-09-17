using AngularApiApp._BLL.Models;
using AngularApiApp._DAL.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApiApp._DAL.Services
{
    public interface DALServiceInterface
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

    public class DALService : DALServiceInterface
    {
        private readonly DALContext _context;

        public DALService(DALContext context)
        {
            _context = context;
        }

        public void AddCategory(CategoryBLLModel category)
        {
            var efCategory = new Category()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Code = category.Code
            };

            _context.Categorys.Add(efCategory);
            _context.SaveChanges();
        }

        public void AddProduct(ProductBLLModel product)
        {
            var efProduct = new Product()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Quantity = product.Quantity,
                Language = product.Language,
                CategoryId = product.Category.CategoryId,
                Category = _context.Categorys.Find(product.Category.CategoryId)
            };
            _context.Products.Add(efProduct);
            _context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            if (_context.Categorys.Find(categoryId) != null)
            {
                _context.Remove(_context.Categorys.Find(categoryId));
                _context.SaveChanges();
            }
            else
            {
                //Todo Throw error here
            }
        }

        public void DeleteProduct(int productId)
        {
            if (_context.Products.Find(productId) != null)
            {
                _context.Remove(_context.Products.Find(productId));
                _context.SaveChanges();
            }
            else
            {
                //Todo Throw error here
            }
        }

        public List<CategoryBLLModel> GetAllCategorys()
        {
            var efCatagorys = _context.Categorys.ToList();
            var BLLCategorys = new List<CategoryBLLModel>();

            foreach (var item in efCatagorys)
            {
                BLLCategorys.Add(new CategoryBLLModel() { 
                    CategoryId = item.CategoryId,
                    Name = item.Name,
                    Code = item.Code
                });
            }
            return BLLCategorys;
        }

        public List<ProductBLLModel> GetAllProducts()
        {
            var efProducts = _context.Products.ToList();
            var BLLProducts = new List<ProductBLLModel>();

            foreach (var item in efProducts)
            {
                var temp = _context.Categorys.Find(item.CategoryId);

                BLLProducts.Add(new ProductBLLModel()
                {
                    ProductId = item.ProductId,
                    Name = item.Name,
                    Quantity = item.Quantity,
                    Language = item.Language,
                    Category = new CategoryBLLModel { CategoryId = temp.CategoryId, Code = temp.Code, Name = temp.Name}
                });
            }
            return BLLProducts;
        }

        public CategoryBLLModel GetCategory(int categoryId)
        {
            var item = _context.Categorys.Find(categoryId);

            return new CategoryBLLModel()
            {
                CategoryId = item.CategoryId,
                Name = item.Name,
                Code = item.Code
            };
        }

        public ProductBLLModel GetProduct(int productId)
        {
            var item = _context.Products.Find(productId);
            var category = _context.Categorys.Find(item.CategoryId);

            return new ProductBLLModel()
            {
                ProductId = item.ProductId,
                Name = item.Name,
                Quantity = item.Quantity,
                Language = item.Language,
                Category = new CategoryBLLModel { CategoryId = category.CategoryId, Code = category.Code, Name = category.Name }
            };
        }

        public void UpdateCategory(CategoryBLLModel category)
        {
            Category DalCategory = _context.Categorys.Find(category.CategoryId);

            if (DalCategory != null)
            {
                DalCategory.Name = category.Name;
                DalCategory.Code = category.Code;

                _context.Categorys.Update(DalCategory);
                _context.SaveChanges();
            }
        }

        public void UpdateProduct(ProductBLLModel product)
        {
            var Dalproduct = _context.Products.Find(product.ProductId);

            if (Dalproduct != null)
            {
                Dalproduct.Name = product.Name;
                Dalproduct.Quantity = product.Quantity;
                Dalproduct.Language = product.Language;
                Dalproduct.CategoryId = product.Category.CategoryId;
                Dalproduct.Category = _context.Categorys.Find(product.Category.CategoryId);

                _context.Products.Add(Dalproduct);
                _context.SaveChanges();
            }
        }
    }
}
