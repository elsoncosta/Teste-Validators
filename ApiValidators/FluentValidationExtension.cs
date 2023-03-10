using FluentValidation;
using FluentValidation.AspNetCore;

namespace ApiValidators
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddFluentValidators(this IServiceCollection services)
        {
            services.AddFluentValidation(conf =>
            {
                services.AddValidatorsFromAssemblyContaining<PessoaValidator>();
                services.AddValidatorsFromAssemblyContaining<EnderecoValidator>();
                conf.AutomaticValidationEnabled = true;
            });

            return services;
        }
    }
}