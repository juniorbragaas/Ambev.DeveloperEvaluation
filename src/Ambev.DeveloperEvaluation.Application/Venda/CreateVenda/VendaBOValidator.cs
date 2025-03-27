using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;

/// <summary>
/// Validator for CreateUserCommand that defines validation rules for user creation command.
/// </summary>
public static class VendaBOValidator 
{
    //Compras acima de 4 itens idênticos têm 10% de desconto.
    public static void DescontoEntre4e9(Venda venda,string id)
    {
        var index = venda.Products.FindIndex((p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase)));
        venda.Products[index].PercentualDesconto = 0.1M;
    }
    // Compras entre 10 e 20 itens idênticos têm 20% de desconto.
    public static void DescontoEntre10e20(Venda venda, string id)
    {
        var index = venda.Products.FindIndex((p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase)));
        venda.Products[index].PercentualDesconto = 0.2M;
    }
    // Compras entre 10 e 20 itens idênticos têm 20% de desconto.
    public static void CalculoValores(Venda venda)
    {
        for (int i = 0; i < venda.Products.Count; i++)
        {
            venda.Products [i].PrecoTotal = (venda.Products[i].Quantidade * venda.Products[i].PrecoUnitario) ;
            venda.Products[i].PrecoTotalDesconto = (venda.Products[i].Quantidade * venda.Products[i].PrecoUnitario) * venda.Products[i].PercentualDesconto;
            venda.Products[i].PrecoTotalAPagar = venda.Products[i].PrecoTotal - venda.Products[i].PrecoTotalDesconto;
        }
    }
}