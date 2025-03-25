using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class FilialRegisteredEvent
    {
        public Filial Filial { get; }

        public FilialRegisteredEvent(Filial filial)
        {
            Filial  = filial;
        }
    }
}
