using System.Xml;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IProdutoRepository using Entity Framework Core
/// </summary>
public class ProdutoRepository : IProdutoRepository
{
    private static string caminhoArquivo = "Banco\\Produto.json";
    public async Task<Produto> CreateAsync(Produto Produto)
    {
        var produtos = await Ler();
        Produto.Id = Guid.NewGuid().ToString();
        produtos.Add(Produto);
        Salvar(produtos);
        return Produto;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var produtos = await Ler();
        var p = produtos.FindIndex(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        produtos.RemoveAt(p);
        Salvar(produtos);
        return true;
    }

    public async Task<Produto> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var produtos = await Ler();
        var resultado = produtos.ToList().Where(p => p.Id.Equals(id)).ToList().FirstOrDefault();
        return resultado;
    }

    public async Task<List<Produto>> ListProdutos()
    {
        var produtos = await Ler();
        return produtos;
    }
    public async Task<List<Produto>> Ler()
    {
        if (!File.Exists(caminhoArquivo))
            return new List<Produto>();

        var json = File.ReadAllText(caminhoArquivo);
        var dado = JsonConvert.DeserializeObject<List<Produto>>(json);
        return dado;
    }

    public async Task<bool> UpdateAsync(string id, Produto Produto, CancellationToken cancellationToken = default)
    {
        var produtos = await Ler();
        var p = produtos.FindIndex(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        produtos[p] = Produto;
        Salvar(produtos);
        return true;

    }

    static void Salvar(List<Produto> Produto)
    {
        var json = JsonConvert.SerializeObject(Produto, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(caminhoArquivo, json);
    }
}
