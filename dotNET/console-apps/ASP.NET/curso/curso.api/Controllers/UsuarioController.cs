using curso.api.Business.Entities;
using curso.api.Business.Repositories;
using curso.api.Configurations;
using curso.api.Filters;
using curso.api.Infraestruture.Data;
using curso.api.Models;
using curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace curso.api.Controllers
{
    //[Route("api/[controller]")] Alterado, versionando API
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository; //Inversão de controles
        //private readonly IConfiguration _configuration; //Realocado IAuthenticationService
        private readonly IAuthenticationService _authenticationService;
        public UsuarioController(
            IUsuarioRepository usuarioRepository,
            IAuthenticationService authenticationService)
        {
            _usuarioRepository = usuarioRepository;
            _authenticationService = authenticationService;
        }


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
        [ValidacaoModelStateCustomizado] //Chamando a verificação de erros
        public IActionResult Logar(LoginViewModelInput loginViewModelInput) //Rota com dados de login de entrada
        {
            //Realocado para uma classe própria em Filters
            //if (!ModelState.IsValid) //Status do modelo é invalido
            //{
            //    return BadRequest(new ValidaCampoViewModelOutput(ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage)));
            //    //Retorna uma BadRequest. Utilizando o Linq, percorrerá todas as listas de erro e devolver as mensagens de ErrorMessage
            //}

            //return Ok(loginViewModelInput); //Return Stauts 200 - OK

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

            var usuario = _usuarioRepository.ObterUsuario(loginViewModelInput.Login);

            if (usuario == null)
            {
                return BadRequest("Houve um erro ao tentar acessar.");
            }

            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = 1,
                Login = "leandro",
                Email = "leandro@gmail.com"
            };

            ////var secret = Encoding.ASCII.GetBytes("MzfsT&d9gprP>!9gprP>!9$Es(X!5g@;ef!5sbk:jH\\2.}8ZP'qY#7");
            //var secret = Encoding.ASCII.GetBytes(_configuration.GetSection("JwtConfigurations:Secret").Value); //Realocado para JwtService
            //var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            //var securityTokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Codigo.ToString()),
            //        new Claim(ClaimTypes.Name, usuarioViewModelOutput.Login.ToString()),
            //        new Claim(ClaimTypes.Email, usuarioViewModelOutput.Email.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(1),
            //    SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256),
            //};

            //var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            //var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            //var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);
            var token = _authenticationService.GerarToken(usuarioViewModelOutput);

            return Ok(new
            {
                Token = token,
                Usuario = usuarioViewModelOutput
            });

        }


        /// <summary>
        /// Este serviço permite cadastrar um usuário cadastrado não existente.
        /// </summary>
        /// <param name="loginViewModelInput">View model do registro de login</param>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar", Type = typeof(RegistroViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(ErroGenericoViewModel))]

        [HttpPost]
        [HttpPost]
        [Route("registrar")] //Renomeando rota
        [ValidacaoModelStateCustomizado]
        public IActionResult Registrar(RegistroViewModelInput loginViewModelInput)
        {
            //var optionsBuilder = new DbContextOptionsBuilder<CursoDbContext>();
            //optionsBuilder.UseSqlServer("Server=localhost;Database=CURSO;user=sa;password=App@223020");

            //CursoDbContext contexto = new CursoDbContext(optionsBuilder.Options); //Realocado para UsuarioRepository

            //var migracoesPendentes = contexto.Database.GetPendingMigrations();

            //if (migracoesPendentes.Count() > 0) //Tem migração aqui que não está na base
            //{
            //    contexto.Database.Migrate();
            //}

            var usuario = new Usuario();
            usuario.Login = loginViewModelInput.Login;
            usuario.Senha = loginViewModelInput.Senha;
            usuario.Email = loginViewModelInput.Email;
            //contexto.Usuario.Add(usuario); //Realocado para UsuarioRepository
            //contexto.SaveChanges(); //Realocado para UsuarioRepository

            _usuarioRepository.Adicionar(usuario); //Inversão de controles
            _usuarioRepository.Commit();

            

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
