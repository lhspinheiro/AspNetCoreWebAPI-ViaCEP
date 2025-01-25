using ViaCep.Integration.Interfaces;
using ViaCep.Integration.Refit;
using ViaCep.Integration.Response;

namespace ViaCep.Integration;

public class ViaCepIntegration : IViaCepIntegration
{
    private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;

    public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
    {
        _viaCepIntegrationRefit = viaCepIntegrationRefit;
    }

    public async Task<ViaCepResponse> ObterCepViaDados(string sigla, string cidade, string endereco)
    {
        var responseCep = await _viaCepIntegrationRefit.ObterCepViaDados(sigla, cidade, endereco);

        if (responseCep != null && responseCep.IsSuccessStatusCode)
        {
            return responseCep.Content.FirstOrDefault();
        }

        return null;
    }

    public async Task<ViaCepResponse> ObterDadosViaCep(string cep)
    {
        var responseData = await _viaCepIntegrationRefit.ObterDadosViaCep(cep);

        if (responseData != null & responseData.IsSuccessStatusCode)
        {
            return responseData.Content;
        }     
        return null; 
    }
}
