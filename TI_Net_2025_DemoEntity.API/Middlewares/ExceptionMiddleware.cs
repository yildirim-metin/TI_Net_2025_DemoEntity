using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using TI_Net_2025_DemoEntity.BLL.Exceptions;

namespace TI_Net_2025_DemoEntity.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public ExceptionMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _requestDelegate(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    public async Task HandleException(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";

        switch (ex)
        {
            case DemoEntityException e:
                await SendResponse(context, e);
                break;

            case Exception:
                context.Response.StatusCode = 400;
                var response = new
                {
                    message = ex.Message,
                };
                string jsonResponse = JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(jsonResponse);
                break;

            default:
                break;
        }
    }
    
    public async Task SendResponse(HttpContext context, DemoEntityException ex)
    {
        context.Response.StatusCode = ex.StatusCode;

        var response = new
        {
            message = ex.Content,
        };
                
        string jsonResponse = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(jsonResponse);
    }
}
