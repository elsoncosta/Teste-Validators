using System;
using FluentValidation;

namespace ApiValidators
{
	public class EnderecoValidator : AbstractValidator<Endereco>
    {
		public EnderecoValidator()
		{
            RuleFor(r => r.Nome).NotEmpty().NotNull();

			// RuleFor(x => x.Id)
            //     .MustAsync(async (id, cancellation) =>
            //     {
            //         bool exists = await IdExists(id);
            //         return !exists;
            //     })
            //     .WithMessage("ID Deve ser único");
        }

		// private static async Task<bool> IdExists(int id)
        // {
        //     for (int i = 0; i < 5; i++)
        //     {
        //         Console.WriteLine("Aguarde mais 1 segundo.");
        //         Thread.Sleep(10000);
        //     }
        //     Console.WriteLine("passou async");
        //     return id.Equals(1) ? true : false;
        // }
	}
}