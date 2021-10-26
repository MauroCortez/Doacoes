using Doacao.Comum.Commands;
using Doacao.Dominio.Commands.Usuario;
using Doacao.Dominio.Handlers.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doacao.Api.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [Route("signup")]
        [HttpPost]
        public GenericCommandResult SignUp(CriarContaCommand command, [FromServices] CriarContaHandle handle)
        {
            return (GenericCommandResult)handle.Handler(command);
        }
    }
}
