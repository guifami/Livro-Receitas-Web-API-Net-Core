namespace LivroDeReceitas.Comunicacao.Response
{
    public class ResponseJsonError
    {
        public List<string> Mensagens { get; set; }
        public ResponseJsonError(string mensagem)
        {
            Mensagens = new List<string>()
            {
                mensagem
            };
        }

        public ResponseJsonError(List<string> mensagens)
        {
            Mensagens = mensagens;
        }
    }
}
