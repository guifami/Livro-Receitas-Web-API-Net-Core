using LivroDeReceitas.Application.UseCases.Usuario.Registrar;
using Microsoft.Extensions.DependencyInjection;

namespace LivroDeReceitas.Application
{
    public static class Bootstrapper
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>();
        }
    }
}
