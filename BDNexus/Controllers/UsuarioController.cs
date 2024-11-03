using _Nexus.Models;
using BDNexus.Requests;
using BDNexus.UseCase;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BDNexus.Controllers
{
    [ApiController]
    [Tags("Usuario")]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioUseCase _usuarioUseCase;

        public UsuarioController(UsuarioUseCase usuarioUseCase)
        {
            _usuarioUseCase = usuarioUseCase;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult<IEnumerable<UsuarioModel>> GetAll()
        {
            var usuarios = _usuarioUseCase.GetAllTasks();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<UsuarioModel> GetById(string id)
        {
            var usuarios = _usuarioUseCase.GetTaskById(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult CreateTask([FromBody] UsuarioRequest request)
        {

            var usuario = new UsuarioModel
            {
                NomeUsuario = request.NomeUsuario,
                CPF = request.CPF,
                Telefone = request.telefone,
                Email = request.email
            };

            _usuarioUseCase.AddTask(usuario);

            return Created();
        }


        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Update(string id, [FromBody] UsuarioRequest request)
        {
            var usuarioToUpdate = _usuarioUseCase.GetTaskById(id);

            if (usuarioToUpdate == null)
            {
                return NotFound();
            }

            usuarioToUpdate.NomeUsuario = request.NomeUsuario;
            usuarioToUpdate.CPF = request.CPF;
            usuarioToUpdate.Email = request.email;
            usuarioToUpdate.Telefone = request.telefone;

            _usuarioUseCase.UpdateTask(usuarioToUpdate);

            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Delete(string id)
        {
            var taskToDelete = _usuarioUseCase.GetTaskById(id);

            if (taskToDelete == null)
            {
                return NotFound();
            }

            _usuarioUseCase.DeleteTask(id);

            return NoContent();
        }
    }
}
