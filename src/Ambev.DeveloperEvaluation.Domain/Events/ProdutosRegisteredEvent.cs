using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class ProdutosRegisteredEvent
    {
        public Produto Produtos { get; }

        public ProdutosRegisteredEvent(Produto Produtos)
        {
            Produtos = Produtos;
        }
    }
}
