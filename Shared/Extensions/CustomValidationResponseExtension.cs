using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shared.Dtos;
using System.Linq;

namespace Shared.Extensions
{
    public static class CustomValidationResponseExtension
    {
        public static void UseCustomValidationResponseExtension(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values.Where(value => value.Errors.Count > 0).SelectMany(value => value.Errors).Select(value => value.ErrorMessage).ToList();

                    var errorDto = new ErrorDto(errors, true);

                    var response = Response<NoContentResult>.Fail(errorDto, 400);

                    return new BadRequestObjectResult(response);
                };
            });
        }
    }
}
