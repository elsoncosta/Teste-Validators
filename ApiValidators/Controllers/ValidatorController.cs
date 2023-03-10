using System;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ApiValidators.Controllers;

[ApiController]
[Route("[controller]")]
public class ValidatorController : ControllerBase
{
    readonly PessoaValidator _validator;
    readonly IValidator<Endereco> _validationsEndereco;

    public ValidatorController(PessoaValidator validations, IValidator<Endereco> validationsEndereco)
    {
        _validator = validations;
        _validationsEndereco = validationsEndereco;
    }

    /// <summary>
    /// Automático com validador ativado para manual
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("/automaticoHabilitado")]
    public async Task<IActionResult> PostAutomaticoHabilitado(Pessoa model)
    {
        _validator._InvalidarValidacao = true;
        ValidationResult validation = await _validator.ValidateAsync(model);
        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }
        return Ok();
    }

    /// <summary>
    /// Automático com validador ativado
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("/Desabilitado")]
    public async Task<IActionResult> PostAutomaticoDesabilitado(Pessoa model)
    {
        return Ok();
    }

    [HttpPost("/automatico")]
    public async Task<IActionResult> PostAutomatico(Endereco model)
    {
        return Ok();
    }
}
