using ViaCep.Integration.Response;

namespace ViaCep.Integration.Interfaces;

public interface IViaCepIntegration 
{
    Task <ViaCepResponse> ObterDadosViaCep (string cep);

    Task   <ViaCepResponse> ObterCepViaDados(string sigla, string cidade, string endereco);
}
