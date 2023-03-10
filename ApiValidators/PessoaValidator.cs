using FluentValidation;
using FluentValidation.Results;

namespace ApiValidators
{
	public class PessoaValidator : AbstractValidator<Pessoa>
    {
        public bool _InvalidarValidacao;
        protected override bool PreValidate(ValidationContext<Pessoa> context, ValidationResult result)
        {
            Console.WriteLine($"Deve execultar: {_InvalidarValidacao}");
            return _InvalidarValidacao;
        }

        public PessoaValidator()
		{
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(0, 10);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Age).InclusiveBetween(18, 60);

            RuleFor(x => x.Id)
                .MustAsync(async (id, cancellation) =>
                {
                    bool exists = await IdExists(id);
                    return !exists;
                })
                .WithMessage("ID Deve ser único");
        }

        private static async Task<bool> IdExists(int id)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Aguarde mais 1 segundo.");
                Thread.Sleep(10000);
            }
            Console.WriteLine("passou async");
            return id.Equals(1);
        }
    }
}