using Refit;
using ViaCep.Integration.Response;

namespace ViaCep.Integration.Refit;

public interface IViaCepIntegrationRefit
{
    [Get("/ws/{cep}/json")] //defini a rota que vai se comunicar
    Task <ApiResponse<ViaCepResponse>> ObterDadosViaCep (string cep);

    [Get("/ws/{sigla}/{cidade}/{endereco}/json")]   
    Task <ApiResponse<List<ViaCepResponse>>> ObterCepViaDados(string sigla, string cidade, string endereco);
}
