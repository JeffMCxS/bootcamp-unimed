using curso.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace curso.api.Filters
{
    public class ValidacaoModelStateCustomizado : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context) //Sobrescrever método padrão
        {
            if (!context.ModelState.IsValid)
            {
                var validaCampoViewModel = new ValidaCampoViewModelOutput(context.ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage));
                //Retorna uma BadRequest. Utilizando o Linq, percorrerá todas as listas de erro e configurar na ValidaCampoViewModelOutput
                context.Result = new BadRequestObjectResult(validaCampoViewModel);
            }
        }
        
    }
}
