namespace TI_Net_2025_DemoEntity.BLL.Exceptions;

public class DemoEntityException : Exception
{
    public int StatusCode { get; set; }
    public object Content { get; set; } = null!;

    public DemoEntityException(int status, object content)
    {
        StatusCode = status;
        Content = content;
    }
}
