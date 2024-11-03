using _Nexus.Models;
using BDNexus.Requests;
using BDNexus.UseCase;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BDNexus.Controllers
{
    [ApiController]
    [Tags("Produtos")]
    [Route("api/Produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoUseCase _produtosUseCase;

        public ProdutosController(ProdutoUseCase produtosUseCase)
        {
            _produtosUseCase = produtosUseCase;
        }

        /// <summary>
        /// Retrieves all tasks
        /// </summary>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public ActionResult<IEnumerable<ProdutosModel>> GetAll()
        {
            var produtos = _produtosUseCase.GetAllTasks();

            return Ok(produtos);
        }

        /// <summary>
        /// Retrieves a specific task by ID
        /// </summary>
        /// <param name="id">The ID of the task</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutosModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public ActionResult<ProdutosModel> GetById(string id)
        {
            var produtos = _produtosUseCase.GetTaskById(id);

            if (produtos == null)
            {
                return NotFound();
            }

            return Ok(produtos);
        }

        /// <summary>
        /// Create a new task
        /// </summary>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult CreateTask([FromBody] ProdutoRequest request)
        {

            var produtos = new ProdutosModel
            {
                NomeProduto = request.NomeProdutos,
                estoque = request.estoque,
                TipoProduto  = request.TipoProduto,
                Marca = request.Marca,
                Modelo = request.Modelo,
                Quantidade = request.Quantidade,
                ValorProduto = request.ValorProduto,
                DescricaoProduto = request.DescricaoProduto,
                status = request .status,
                codigoProduto =  request.codigoProduto,
            };

            _produtosUseCase.AddTask(produtos);

            return Created();
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Update(string id, [FromBody] ProdutoRequest request)
        {
            var produtosToUpdate = _produtosUseCase.GetTaskById(id);

            if (produtosToUpdate == null)
            {
                return NotFound();
            }

            produtosToUpdate.NomeProduto = request.NomeProdutos;
            produtosToUpdate.estoque = request.estoque;
            produtosToUpdate.TipoProduto = request.TipoProduto;
            produtosToUpdate.Marca = request.Marca;
            produtosToUpdate.Modelo = request.Modelo;
            produtosToUpdate.Quantidade = request.Quantidade;
            produtosToUpdate.ValorProduto = request.ValorProduto;
            produtosToUpdate.DescricaoProduto = request.DescricaoProduto;
            produtosToUpdate.status = request.status;
            produtosToUpdate.codigoProduto = request.codigoProduto;

            _produtosUseCase.UpdateTask(produtosToUpdate);

            return NoContent();
        }

        /// <summary>
        /// Deletes a task by id
        /// </summary>
        /// <param name="id">The ID of the task</param>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Delete(string id)
        {
            var produtosToDelete = _produtosUseCase.GetTaskById(id);

            if (produtosToDelete == null)
            {
                return NotFound();
            }

            _produtosUseCase.DeleteTask(id);

            return NoContent();
        }
    }
}