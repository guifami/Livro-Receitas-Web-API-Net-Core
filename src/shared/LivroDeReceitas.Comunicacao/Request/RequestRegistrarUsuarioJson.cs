﻿using LivroDeReceitas.Domain.Entities;

namespace LivroDeReceitas.Comunicacao.Request
{
    public class RequestRegistrarUsuarioJson : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
    }
}