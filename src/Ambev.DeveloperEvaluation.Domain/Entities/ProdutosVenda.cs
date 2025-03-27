using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a product in the system with its details and business rules validation.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class ProdutosVenda
    {
        /// <summary>
        /// Gets or sets the product's name.
        /// Must not be null or empty and should represent the product's descriptive name.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product available in stock.
        /// Must be a non-negative integer.
        /// </summary>
        public int Quantidade { get; set; }


        /// <summary>
        /// Gets or sets the price of the product.
        /// Must be a positive value.
        /// </summary>
        public decimal PrecoTotal { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// Must be a positive value.
        /// </summary>
        public decimal PercentualDesconto { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// Must be a positive value.
        /// </summary>
        public decimal PrecoTotalDesconto { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// Must be a positive value.
        /// </summary>
        public decimal PrecoTotalAPagar { get; set; }

    }
}

