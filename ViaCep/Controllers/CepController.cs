using Microsoft.AspNetCore.Mvc;
using ViaCep.Integration.Interfaces;
using ViaCep.Integration.Response;

namespace ViaCep.Controllers;

[ApiController]
[Route("[controller]")]
public class CepController : ControllerBase
{

    private readonly IViaCepIntegration _viaCepIntegration;
    public CepController(IViaCepIntegration viaCepIntegration)
    {
        _viaCepIntegration = viaCepIntegration;
    }


// Endpoint para retornar os dados a paritr de um CEP
    [HttpGet]
    [Route("{cep}")]
    public async Task <ActionResult<ViaCepResponse>> ViaCep([FromRoute]string cep)
    {
        var result =  await _viaCepIntegration.ObterDadosViaCep(cep);

        if (result == null)
        {
            return NotFound("Cep não encontrado");
        }
        return Ok(result);
    }

// Endpoint para saber o CEP, caso seja necessário.   

    [HttpGet]
    [Route("{sigla}/{cidade}/{endereco}")]
    public async Task <ActionResult<ViaCepResponse>> ObterCep([FromRoute]string sigla, string cidade, string endereco)
    {
        var results = await _viaCepIntegration.ObterCepViaDados(sigla, cidade, endereco);

        if (results is null)
        {
            return NotFound("Não foi possível localizar os dados para este endereço!");
        }
        return Ok(results); 
    } 
}
