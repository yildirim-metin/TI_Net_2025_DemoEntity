namespace TI_Net_2025_DemoEntity.BLL.Exceptions;

public class NotFoundException : DemoEntityException
{
    public NotFoundException(string message) : base(404, message)
    {
    }
}
