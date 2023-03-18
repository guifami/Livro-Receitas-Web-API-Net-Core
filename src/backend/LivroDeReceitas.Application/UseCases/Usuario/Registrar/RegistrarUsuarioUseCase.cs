using AutoMapper;
using LivroDeReceitas.Comunicacao.Request;
using LivroDeReceitas.Domain.Repositories;
using LivroDeReceitas.Exceptions.ExceptionsBase;

namespace LivroDeReceitas.Application.UseCases.Usuario.Registrar
{
    public class RegistrarUsuarioUseCase : IRegistrarUsuarioUseCase
    {
        private readonly IUsuarioWriteOnlyRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        public RegistrarUsuarioUseCase(IUsuarioWriteOnlyRepository repository, IMapper mapper, IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            _repository = repository;
            _mapper = mapper;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }

        public async Task Executar(RequestRegistrarUsuarioJson request)
        {
            Validar(request);

            var entidade = _mapper.Map<Domain.Entities.Usuario>(request);
            entidade.Senha = "cript";

            await _repository.AdicionarUsuario(entidade);

            await _unidadeDeTrabalho.Commit();
        }

        private void Validar(RequestRegistrarUsuarioJson request)
        {
            var validator = new RegistrarUsuarioValidator();
            var resultado = validator.Validate(request);

            if (!resultado.IsValid)
            {
                var mensagensDeErro = resultado.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErrosDeValidacaoException(mensagensDeErro);
            }
        }
    }
}
