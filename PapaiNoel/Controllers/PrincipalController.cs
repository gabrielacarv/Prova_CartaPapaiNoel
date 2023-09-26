using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PapaiNoel.Configuration;

namespace PapaiNoel.Controllers
{
    public class PrincipalController : ControllerBase
    {
        protected IActionResult ApiResponse<T>(T dados, string menssagem = null)
        {
            var response = new RetornoCustomizado<T>
            {
                Sucesso = true,
                Menssagem = menssagem,
                Dados = dados
            };
            return Ok(response);
        }

        protected IActionResult ApiBadRequestResponse(ModelStateDictionary modelState, string message = "Dados inválidos")
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            var response = new RetornoCustomizado<object>
            {
                Sucesso = false,
                Menssagem = message,
                Dados = erros.Select(n => n.ErrorMessage).ToArray(),
                Status = 500
            };
            return BadRequest(response);
        }
    }
}
