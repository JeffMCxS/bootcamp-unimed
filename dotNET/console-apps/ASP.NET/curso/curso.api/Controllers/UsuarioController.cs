using curso.api.Models;
using curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace curso.api.Controllers
{
    //[Route("api/[controller]")] Alterado, versionando API
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        /// <summary>
        /// Este serviço permite autenticar um usuário cadastrado e ativo.
        /// </summary>
        /// <param name="loginViewModelInput">View model do login</param>
        /// <returns>Retorna status ok, dados do usuario e o token em caso de sucesso</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))] //Definindo retornos para cada tipo de status code
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]

        [HttpPost] //Anotando rota com verbo Post da API Rest
        [Route("logar")] //Renomeando rota
        public IActionResult Logar(LoginViewModelInput loginViewModelInput) //Rota com dados de login de entrada
        {
            return Ok(loginViewModelInput); //Return Stauts 200 - OK

            /* Teste Postman
     
            Tipo: POST
            Rota/URL: https://localhost:44327/api/v1/usuario/logar > porta do projeto vs + route do controller
            Corpo > Raw > JSON
                {
                    "login" : "teste",
                    "senha" : "senha"
                }
            Anotações: Desabilitar SSL
            Retorno: 200 - OK
            */
        }

        [HttpPost]
        [Route("registrar")] //Renomeando rota
        public IActionResult Registrar(RegistroViewModelInput loginViewModelInput)
        {
            return Created("", loginViewModelInput); //Return Status 201 - Created

            /* Teste Postman
     
            Tipo: POST
            Rota/URL: https://localhost:44327/api/v1/usuario/registrar > porta do projeto vs + route do controller
            Corpo > Raw > JSON
                {
                    "Login" : "leandro",
                    "Senha" : "123",
                    "Email" : "email@email.com"
                }
            Anotações: Desabilitar SSL
            Retorno: 201 - CREATED
            */
        }

    }
}
