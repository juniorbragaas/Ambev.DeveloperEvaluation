using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a branch (filial) in the system with its details and business rules validation.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Filial 
    {
        public string Id { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the branch's name.
        /// Must not be null or empty and should represent the branch's descriptive name.
        /// </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the branch's address.
        /// Must contain street, number, city, state, and postal code.
        /// </summary>
        public string Endereco { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the branch's phone number.
        /// Must be a valid phone number format following the pattern (XX) XXXXX-XXXX.
        /// </summary>
        public string Telefone { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the branch's email address.
        /// Must be a valid email format.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets the date and time when the branch was created.
        /// </summary>
        public string CriadoEm { get; set; } = string.Empty;

        /// <summary>
        /// Gets the date and time of the last update to the branch's information.
        /// </summary>
        public string AtualizadoEm { get; set; } = string.Empty;

    }
}
