using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class ClienteRegisteredEvent
    {
        public Cliente Cliente { get; }

        public ClienteRegisteredEvent(Cliente cliente)
        {
            Cliente = cliente;
        }
    }
}
