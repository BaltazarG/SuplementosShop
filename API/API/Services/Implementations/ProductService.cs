using API.Entities;
using API.Models.ProductModels;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using AutoMapper;

namespace API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<bool> AddProduct(ProductToCreationDto product)
        {
            var mapped = _mapper.Map<Product>(product);

            return await _productRepository.AddProduct(mapped);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            return await _productRepository.DeleteProduct(productId);
        }

        public async Task<ProductDto?> GetProductById(int productId)
        {
            var product = await _productRepository.GetProductById(productId);


            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto?>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            return _mapper.Map<ICollection<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto?>> GetProductsByCategory(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategory(categoryId);


            return _mapper.Map<ICollection<ProductDto>>(products);
        }

        public async Task<bool> UpdateProduct(ProductToUpdateDto product, int productId)
        {
            var mapped = _mapper.Map<Product>(product);

            mapped.Id = productId;

            return await _productRepository.UpdateProduct(mapped);

        }
    }
}
