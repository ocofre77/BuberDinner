using System.Net;
using System.Text.Json;

namespace BuberDinner.Api.Middleware;
public class ErrorHandlingMiddleware{

    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context){
        try{
            await _next(context);
        }
        catch(Exception ex)
        {
            await HandleExceptionAsync(context,ex);
        }
    }

    private static Task HandleExceptionAsync(Microsoft.AspNetCore.Http.HttpContext context, Exception ex){
        var code = HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new { error = "An error ocurrer while procesing your request" });
        context.Response.ContentType ="application/json";
        context.Response.StatusCode = (int) code;
        return context.Response.WriteAsync(result); 
    }

}