using System;
using FluentValidation;

namespace ApiValidators
{
	public class EnderecoValidator : AbstractValidator<Endereco>
    {
		public EnderecoValidator()
		{
            RuleFor(r => r.Nome).NotEmpty().NotNull();
        }
	}
}