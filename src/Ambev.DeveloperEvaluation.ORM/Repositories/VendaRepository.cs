using System.Xml;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IVendaRepository using Entity Framework Core
/// </summary>
public class VendaRepository : IVendaRepository
{
    private static string caminhoArquivo = "Banco\\Venda.json";
    public async Task<Venda> CreateAsync(Venda Venda)
    {
        var Vendas = await Ler();
        Venda.Id = Guid.NewGuid().ToString();
        Vendas.Add(Venda);
        Salvar(Vendas);
        return Venda;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var Vendas = await Ler();
        var p = Vendas.FindIndex(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        Vendas.RemoveAt(p);
        Salvar(Vendas);
        return true;
    }

    public async Task<Venda> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var Vendas = await Ler();
        var resultado = Vendas.ToList().Where(p => p.Id.Equals(id)).ToList().FirstOrDefault();
        return resultado;
    }

    public async Task<List<Venda>> ListVendas()
    {
        var Vendas = await Ler();
        return Vendas;
    }
    public async Task<List<Venda>> Ler()
    {
        if (!File.Exists(caminhoArquivo))
            return new List<Venda>();

        var json = File.ReadAllText(caminhoArquivo);
        var dado = JsonConvert.DeserializeObject<List<Venda>>(json);
        return dado;
    }

    public async Task<bool> UpdateAsync(string id, Venda Venda, CancellationToken cancellationToken = default)
    {
        var Vendas = await Ler();
        var p = Vendas.FindIndex(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        Vendas[p] = Venda;
        Salvar(Vendas);
        return true;

    }

    static void Salvar(List<Venda> Venda)
    {
        var json = JsonConvert.SerializeObject(Venda, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(caminhoArquivo, json);
    }
}
