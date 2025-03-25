using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class ProdutosRegisteredEvent
    {
        public Produtos Produtos { get; }

        public ProdutosRegisteredEvent(Produtos Produtos)
        {
            Produtos = Produtos;
        }
    }
}
