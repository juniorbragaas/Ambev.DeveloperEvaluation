using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;

/// <summary>
/// Validator for CreateUserCommand that defines validation rules for user creation command.
/// </summary>
public class VendaBOValidator : AbstractValidator<CreateUserCommand>
{
    public Venda DescontoEntre4e9(Venda venda,string id)
    {
        var produto = venda.Products.Where(p => p.Id.Equals(id));

        return venda;
    }

    //Compras acima de 4 itens idênticos têm 10% de desconto.

    // Compras entre 10 e 20 itens idênticos têm 20% de desconto.


    // Não é possível vender mais de 20 itens idênticos.


    // Compras abaixo de 4 itens não podem ter desconto.

    // Essas regras de negócios definem faixas de descontos baseadas na quantidade e limitações:


    // Faixas de Desconto:

    //4 ou mais itens: 10% de desconto.

    //10 a 20 itens: 20% de desconto.

}