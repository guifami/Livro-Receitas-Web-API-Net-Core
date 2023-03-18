using LivroDeReceitas.Comunicacao.Response;
using LivroDeReceitas.Exceptions;
using LivroDeReceitas.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace LivroDeReceitas.Api.Filtros
{
    public class FiltroDasExceptions : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is LivroDeReceitasException)
            {
                tratarLivroDeReceitasException(context);
            }
            else
            {
                lancarErroDesconhecido(context);
            }
        }

        private void tratarLivroDeReceitasException(ExceptionContext context)
        {
            if (context.Exception is ErrosDeValidacaoException)
            {
                TratarErrosDeValidacaoException(context);
            }
        }

        private void TratarErrosDeValidacaoException(ExceptionContext context)
        {
            var erroDeValidacaoException = context.Exception as ErrosDeValidacaoException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult(new ResponseJsonError(erroDeValidacaoException.MensagensDeErro));
        }

        private void lancarErroDesconhecido(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseJsonError(ResourceMensagensDeErro.ErroDesconhecido));
        }
    }
}
