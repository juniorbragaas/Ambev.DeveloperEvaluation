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
    public class Produtos : BaseEntity
    {
        /// <summary>
        /// Gets or sets the product's name.
        /// Must not be null or empty and should represent the product's descriptive name.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product's unique identifier or code.
        /// Must be unique for each product in the system.
        /// </summary>
        public string Codigo { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price of the product.
        /// Must be a positive value.
        /// </summary>
        public decimal Preco { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// Must be a positive value.
        /// </summary>
        public decimal PrecoComDesconto { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product available in stock.
        /// Must be a non-negative integer.
        /// </summary>
        public int QuantidadeEmEstoque { get; set; }

        /// <summary>
        /// Gets or sets the category of the product.
        /// Represents the classification of the product, like electronics, clothing, etc.
        /// </summary>
        public string Categoria { get; set; } = string.Empty;

        /// <summary>
        /// Gets the date and time when the product was created.
        /// </summary>
        public DateTime CriadoEm { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the product's information.
        /// </summary>
        public DateTime? AtualizadoEm { get; set; }

        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        public Produtos()
        {
            CriadoEm = DateTime.UtcNow;
        }

        
    }
}

