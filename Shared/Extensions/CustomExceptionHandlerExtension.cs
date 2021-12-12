using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Shared.Dtos;
using Shared.Exceptions;
using System.Text.Json;

namespace Shared.Extensions
{
    public static class CustomExceptionHandlerExtension
    {
        public static void UseCustomExceptionExtention(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (errorFeature == null) return;

                    var exception = errorFeature.Error;

                    var errorDto = new ErrorDto(exception.Message, exception is CustomException);

                    var response = Response<NoDataDto>.Fail(errorDto, 500);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
