using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class VendaRegisteredEvent
    {
        public Venda Venda { get; }

        public VendaRegisteredEvent(Venda venda)
        {
            Venda = venda;
        }
    }
}
