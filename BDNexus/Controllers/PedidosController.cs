using _Nexus.Models;
using BDNexus.Requests;
using BDNexus.UseCase;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BDNexus.Controllers
{
    [ApiController]
    [Tags("Pedidos")]
    [Route("api/pedidos")]
    public class PedidosController : ControllerBase
    {
        private readonly PedidosUseCase _pedidosUseCase;

        public PedidosController(PedidosUseCase pedidosUseCase)
        {
            _pedidosUseCase = pedidosUseCase;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult<IEnumerable<PedidosModel>> GetAll()
        {
            var pedidos = _pedidosUseCase.GetAllTasks();

            return Ok(pedidos);
        }

 
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PedidosModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<PedidosModel> GetById(string id)
        {
            var pedidos = _pedidosUseCase.GetTaskById(id);

            if (pedidos == null)
            {
                return NotFound();
            }

            return Ok(pedidos);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult CreateTask([FromBody] PedidoRequest request)
        {

            var pedidos = new PedidosModel
            {
                CodigoPedido = request.CodigoPedido,
                Quantidade = request.Quantidade,
                ValorPedido = request.ValorPedido
            };

            _pedidosUseCase.AddTask(pedidos);

            return Created();
        }


        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Update(string id, [FromBody] PedidoRequest request)
        {
            var pedidoToUpdate = _pedidosUseCase.GetTaskById(id);

            if (pedidoToUpdate == null)
            {
                return NotFound();
            }

            pedidoToUpdate.CodigoPedido = request.CodigoPedido;
            pedidoToUpdate.Quantidade = request.Quantidade;
            pedidoToUpdate.ValorPedido = request.ValorPedido;

            _pedidosUseCase.UpdateTask(pedidoToUpdate);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Delete(string id)
        {
            var pedidoToDelete = _pedidosUseCase.GetTaskById(id);

            if (pedidoToDelete == null)
            {
                return NotFound();
            }

            _pedidosUseCase.DeleteTask(id);

            return NoContent();
        }
    }
}
