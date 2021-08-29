using CodeTur.Comum.Comands;
using CodeTur.Dominio;
using CodeTur.Dominio.Commands.Autenticacao;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Handlers.Autenticacao;
using CodeTur.Dominio.Handlers.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Api.Controllers
{
    //Define a rota
    [Route("v1/account]")]

    //Define que é um controlador
    [ApiController]

    //Criada a classe controller, herda de controllerBase
    public class UsuarioController : ControllerBase
    {
        [Route("signup")]
        //método de cadastro
        [HttpPost]

        //CriarContaCommand = fazer login
        //CriarContaHandle = manipulador de dados
        public GenericCommandResult signUp(CriarContaCommand command, [FromServices] CriarContaHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }




        [Route("signin")]
        [HttpPost]
        public GenericCommandResult SignIn(LogarCommand command, [FromServices] LogarHandle handle)
        {
            var resultado = (GenericCommandResult)handle.Handler(command);

            //Se o resultado for bem sucedido
            if (resultado.Sucesso)
            {
                //gera um token para o usuário
                var token = GenerateJSONWebToken((Usuario)resultado.Data);

                //retorna uma mensagem de bem sucedido, e um token
                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, new {Token = token });
            }

            //Caso dê erro, passa mensagem 
            return new GenericCommandResult(false, resultado.Mensagem, resultado.Data);
        }


        // Criamos nosso método que vai gerar nosso Token
        private string GenerateJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaCodeTurSenai132"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.TipoUsuario.ToString()),
                new Claim("role", userInfo.TipoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())
            };

            // Configuramos nosso Token e seu tempo de vida do token
            var token = new JwtSecurityToken
                (
                    "CodeTur",
                    "CodeTur",
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
