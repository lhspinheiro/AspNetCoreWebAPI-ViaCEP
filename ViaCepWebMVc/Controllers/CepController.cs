using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ViaCepWebMVc.Models;

namespace ViaCepWebMVc.Controllers
{
    public class CepController : Controller
    {
        private readonly HttpClient _httpClient;

        public CepController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ViaCepAPI");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> BuscarCep(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
            {
                ViewBag.Error = "Por favor, insira um CEP válido.";
                return View("Index");
            }

            var response = await _httpClient.GetAsync($"http://localhost:5087/Cep/{cep}");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "CEP não encontrado ou inválido.";
                return View("Index");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var dadosCep = JsonSerializer.Deserialize<ViaCepResponse>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Passando os dados para a View com um ViewModel ou ViewBag
            return View("Index", dadosCep);
        }
    }
}
