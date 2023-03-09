using DynamicStore.Repository;
using DynamicStore.Interface;
using DynamicStore.Models;

namespace DynamicStore.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ProductRepository _productRepository;

        public ProductServices(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            return await _productRepository.AddAsync(product);
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);

            if (existingProduct == null)
            {
                throw new ArgumentException($"Product with id {id} not found");
            }

            // Update the product properties
            if (!string.IsNullOrWhiteSpace(product.ProductName))
            {
                existingProduct.ProductName = product.ProductName;
            }

            if (!string.IsNullOrWhiteSpace(product.ProductDescription))
            {
                existingProduct.ProductDescription = product.ProductDescription;
            }

            if (product.ProductPrice != 0)
            {
                existingProduct.ProductPrice = product.ProductPrice;
            }

            return await _productRepository.UpdateAsync(id, existingProduct);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }
}
