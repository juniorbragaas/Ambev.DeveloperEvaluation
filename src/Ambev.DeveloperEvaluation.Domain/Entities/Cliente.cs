using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a customer in the system with profile information and business rules validation.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Cliente : BaseEntity
    {
        /// <summary>
        /// Gets the customer's full name.
        /// Must not be null or empty and should contain both first and last names.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Gets the customer's email address.
        /// Must be a valid email format and is used as a unique identifier for authentication.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets the customer's phone number.
        /// Must be a valid phone number format following the pattern (XX) XXXXX-XXXX.
        /// </summary>
        public string Telefone { get; set; } = string.Empty;

        /// <summary>
        /// Gets the customer's address.
        /// Must contain street, number, city, state, and postal code.
        /// </summary>
        public string Endereco { get; set; } = string.Empty;

        

        /// <summary>
        /// Gets the date and time when the customer was created.
        /// </summary>
        public DateTime CriadoEm { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the customer's information.
        /// </summary>
        public DateTime? AtualizadoEm { get; set; }

        
        /// <summary>
        /// Initializes a new instance of the Cliente class.
        /// </summary>
        public Cliente()
        {
            CriadoEm = DateTime.UtcNow;
        }

        
    }
}

