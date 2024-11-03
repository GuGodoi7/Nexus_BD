using _Nexus.Models;
using _Nexus.Repository;
using MongoDB.Bson;

namespace BDNexus.UseCase
{
    public class PedidosUseCase
    {
        private readonly IRepository<PedidosModel> _pedidoRepository;

        public PedidosUseCase(IRepository<PedidosModel> pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public IEnumerable<PedidosModel> GetAllTasks()
        {
            return _pedidoRepository.GetAll();
        }

        public PedidosModel GetTaskById(string id)
        {
            return _pedidoRepository.GetById(id);
        }

        public void AddTask(PedidosModel pedidos)
        {
            if (string.IsNullOrEmpty(pedidos.IdPedido))
            {
                pedidos.IdPedido = ObjectId.GenerateNewId().ToString();
            }

            _pedidoRepository.Add(pedidos);
        }

        public void UpdateTask(PedidosModel pedidos)
        {
            _pedidoRepository.Update(pedidos);
        }

        public void DeleteTask(string id)
        {
            _pedidoRepository.Delete(id);
        }
    }
}