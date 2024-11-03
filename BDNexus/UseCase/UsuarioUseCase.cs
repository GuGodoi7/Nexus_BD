using _Nexus.Models;
using _Nexus.Repository;
using MongoDB.Bson;

namespace BDNexus.UseCase
{
    public class UsuarioUseCase
    {
        private readonly IRepository<UsuarioModel> _usuarioRepository;

        public UsuarioUseCase(IRepository<UsuarioModel> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<UsuarioModel> GetAllTasks()
        {
            return _usuarioRepository.GetAll();
        }

        public UsuarioModel GetTaskById(string id)
        {
            return _usuarioRepository.GetById(id);
        }

        public void AddTask(UsuarioModel usuario)
        {
            if (string.IsNullOrEmpty(usuario.Id))
            {
                usuario.Id = ObjectId.GenerateNewId().ToString();
            }

            _usuarioRepository.Add(usuario);
        }

        public void UpdateTask(UsuarioModel usuario)
        {
            _usuarioRepository.Update(usuario);
        }

        public void DeleteTask(string id)
        {
            _usuarioRepository.Delete(id);
        }

    }
}
