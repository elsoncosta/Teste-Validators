using System;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ApiValidators.Controllers;

[ApiController]
[Route("[controller]")]
public class ValidatorController : ControllerBase
{
    readonly IValidator<Pessoa> _validator;
    readonly IValidator<Endereco> _validationsEndereco;

    public ValidatorController(IValidator<Pessoa> validations, IValidator<Endereco> validationsEndereco)
    {
        _validator = validations;
        _validationsEndereco = validationsEndereco;
    }

    [HttpPost("/automatico")]
    public async Task<IActionResult> PostAutomatico(Pessoa model)
    {
        // ValidationResult validation = await _validator.ValidateAsync(model);
        // if (!validation.IsValid)
        // {
        //     return BadRequest(validation.Errors);
        // }
        return Ok();
    }

    [HttpPost("/manual")]
    public async Task<IActionResult> PostManual(Endereco model)
    {
        ValidationResult validation = await _validationsEndereco.ValidateAsync(model);

        if (!validation.IsValid)
        {
            return BadRequest(validation.Errors);
        }
        return Ok();
    }
}

