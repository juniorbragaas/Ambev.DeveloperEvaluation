using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IClienteRepository using Entity Framework Core
/// </summary>
public class ClienteRepository : IClienteRepository
{
    private static string caminhoArquivo = "Banco\\cliente.json";
    public async Task<Cliente> CreateAsync(Cliente cliente)
    {
        var clientes = await Ler();
        cliente.Id = Guid.NewGuid().ToString();
        clientes.Add(cliente);
        Salvar(clientes);
        return cliente;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var clientes = await Ler();
        var p = clientes.FindIndex(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        clientes.RemoveAt(p);
        Salvar(clientes);
        return true;
    }

    public async Task<Cliente> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var clientes = await Ler();
        var resultado = clientes.ToList().Where(p => p.Id.Equals(id)).ToList().FirstOrDefault();
        return resultado;
    }

    public async Task<List<Cliente>> ListClientes()
    {
        var clientes = await Ler();
        return clientes;
    }
    public async Task<List<Cliente>> Ler()
    {
        if (!File.Exists(caminhoArquivo))
            return new List<Cliente>();

        var json = File.ReadAllText(caminhoArquivo);
        var dado = JsonConvert.DeserializeObject<List<Cliente>>(json);
        return dado;
    }

    public async Task<bool> UpdateAsync(string id, Cliente cliente, CancellationToken cancellationToken = default)
    {
        var clientes = await Ler();
        var p = clientes.FindIndex(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        clientes[p] = cliente;
        Salvar(clientes);
        return true;

    }

    static void Salvar(List<Cliente> cliente)
    {
        var json = JsonConvert.SerializeObject(cliente, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(caminhoArquivo, json);
    }
}
