using TI_Net_2025_DemoEntity.DAL.Repositories;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.BLL.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;

    public ProductService(ProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<Product> GetAll()
    {
        return [.. _productRepository.GetAll()];
    }

    public Product GetOne(int id)
    {
        return _productRepository.GetOne(id) ?? throw new NullReferenceException("Product not found!");
    }

    public void Add(Product product)
    {
        _productRepository.Add(product);
    }

    public void Update(int id, Product product)
    {
        Product? existingProduct = GetOne(id);

        if (existingProduct is not null)
        {
            existingProduct.Price = product.Price;
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;

            _productRepository.Update(existingProduct);
        }
    }

    public void Delete(int id)
    {
        _productRepository.Delete(id);
    }
}