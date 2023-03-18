using LivroDeReceitas.Comunicacao.Request;

namespace LivroDeReceitas.Application.UseCases.Usuario.Registrar
{
    public interface IRegistrarUsuarioUseCase
    {
        Task Executar(RequestRegistrarUsuarioJson request);
    }
}
