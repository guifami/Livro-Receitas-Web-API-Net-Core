using AutoMapper;

namespace LivroDeReceitas.Application.Services.AutoMapper
{
    public class AutoMapperConfiguracao : Profile
    {
        public AutoMapperConfiguracao()
        {
            CreateMap<Comunicacao.Request.RequestRegistrarUsuarioJson, Domain.Entities.Usuario>()
                .ForMember(destino => destino.Senha, config => config.Ignore());


        }
    }
}
