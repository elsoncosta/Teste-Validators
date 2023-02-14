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
                // conf.RegisterValidatorsFromAssemblyContaining(typeof(EnderecoValidator));
                services.AddValidatorsFromAssemblyContaining<PessoaValidator>();
                conf.AutomaticValidationEnabled = true;
            });

            // services.AddValidatorsFromAssemblyContaining<PessoaValidator>();
            services.AddValidatorsFromAssemblyContaining<EnderecoValidator>();

            return services;
        }
    }
}