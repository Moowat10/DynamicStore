using DynamicStore.Interface;
using DynamicStore.Models;
using DynamicStore.Repository;


namespace DynamicStore.Services
{
    public class ProductStoreServices : IProductStoreServices
    {
        private readonly ProductStoreRepository _repository;

        public ProductStoreServices(ProductStoreRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductStore>> GetProductStoresAsync()
        {
            var productStores = await _repository.GetAllAsync();
            return productStores;
        }
        public async Task<IEnumerable<ProductStore>> GetProductStoresByProductIdAsync(int productId)
        {
            var stores = await _repository.GetProductStoresByProductIdAsync(productId);
            return stores;
        }
        public async Task<IEnumerable<ProductStore>> GetProductStoresByStoreIdAsync(int productId)
        {
            var products = await _repository.GetProductStoresByStoreIdAsync(productId);
            return products;
        }
        public async Task<ProductStore> GetProductStoreByIdAsync(int id)
        {
            var productStore = await _repository.GetByIdAsync(id);
            return productStore;
        }

        public async Task<ProductStore> AddProductStoreAsync(ProductStore productStore)
        {
            var newProductStore = await _repository.AddAsync(productStore);
            return newProductStore;
        }

        public async Task<ProductStore> UpdateProductStoreAsync(int id, ProductStore productStore)
        {
            var existingProductStore = await _repository.GetByIdAsync(id);

            if (existingProductStore == null)
            {
                return null;
            }

            if (productStore.ProductId != null)
            {
                existingProductStore.ProductId = productStore.ProductId;
            }

            if (productStore.StoreId != null)
            {
                existingProductStore.StoreId = productStore.StoreId;
            }

            var updatedProductStore = await _repository.UpdateAsync(id, existingProductStore);
            return updatedProductStore;
        }

        public async Task<bool> DeleteProductStoreAsync(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            return deleted;
        }
    }
}
