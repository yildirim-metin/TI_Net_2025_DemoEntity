namespace TI_Net_2025_DemoEntity.BLL.Exceptions;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException() : this("Product not found.")
    {
        
    }
    public ProductNotFoundException(string message) : base(message)
    {
    }
}
