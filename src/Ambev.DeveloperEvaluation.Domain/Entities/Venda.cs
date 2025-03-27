using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a sale in the system with its details and business rules validation.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Venda
    {

        /// <summary>
        /// Gets or sets the sale's unique identifier.
        /// Must be a unique identifier for the sale.
        /// </summary>
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the sale's unique identifier.
        /// Must be a unique identifier for the sale.
        /// </summary>
        public string NumeroVenda { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the date when the sale was made.
        /// </summary>
        public DateTime DataVenda { get; set; }

        /// <summary>
        /// Gets or sets the customer associated with the sale.
        /// </summary>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the sale.
        /// This represents the sum of all items and any applied discounts.
        /// </summary>
        public decimal ValorTotalBruto { get; set; }
        public decimal ValorTotalDesconto { get; set; }

        public decimal ValorFinal { get; set; }

        /// <summary>
        /// Gets or sets the branch (Filial) where the sale was made.
        /// </summary>
        public Filial Filial { get; set; }

        /// <summary>
        /// Gets or sets the list of products sold in the sale.
        /// </summary>
        public List<ProdutosVenda> Products { get; set; } = new List<ProdutosVenda>();

        /// <summary>
        /// Gets or sets whether the sale was cancelled or not.
        /// </summary>
        public bool Cancelada { get; set; }  

        /// <summary>
        /// Gets the date and time when the sale was created.
        /// </summary>
        public string DataDaVenda { get; set; } =  string.Empty;

        /// <summary>
        /// Gets the date and time of the last update to the sale's information.
        /// </summary>
        public string AtualizadoEm { get; set; }  = string.Empty;

        
       
    }
}
