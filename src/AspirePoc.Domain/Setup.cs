using AspirePoc.Core.UseCases.Books;
using AspirePoc.Core.UseCases.Books.AddBook;
using AspirePoc.Core.UseCases.Books.UpdateBook;
using AspirePoc.Core.UseCases.Books.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AspirePoc.Core
{
    public static class Setup
    {
        public static IServiceCollection CoreProjectSetup(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IValidator<AddBookRequest>, AddBookValidator>();
            services.AddScoped<IValidator<UpdateBookRequest>, UpdateBookValidator>();

            return services;
        }
    }
}
