using LivroDeReceitas.Application.UseCases.Usuario.Registrar;
using Microsoft.AspNetCore.Mvc;

namespace LivroDeReceitas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get([FromServices] IRegistrarUsuarioUseCase useCase)
        {
            await useCase.Executar(new Comunicacao.Request.RequestRegistrarUsuarioJson
            {
                Email = "well@gmail.com",
                Nome = "Well",
                Senha = "123456",
                Telefone = "11 9 1234-5678"
            });

            return Ok();
        }
    }
}