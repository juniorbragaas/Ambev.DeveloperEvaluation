using System.Xml;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IFilialRepository using Entity Framework Core
/// </summary>
public class FilialRepository : IFilialRepository
{
    private static string caminhoArquivo = "Banco\\Filial.json";
    public async Task<Filial> CreateAsync(Filial filial)
    {
        var filiais = await Ler();
        filial.Id = Guid.NewGuid().ToString();
        filiais.Add(filial);
        Salvar(filiais);
        return filial;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var filiais = await Ler();
        var p = filiais.FindIndex(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        filiais.RemoveAt(p);
        Salvar(filiais);
        return true;
    }

    public async Task<Filial> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var filiais = await Ler();
        var resultado = filiais.ToList().Where(p => p.Id.Equals(id)).ToList().FirstOrDefault();
        return resultado;
    }

    public async Task<List<Filial>> ListFiliais()
    {
        var filiais = await Ler();
        return filiais;
    }
    public async Task<List<Filial>> Ler()
    {
        if (!File.Exists(caminhoArquivo))
            return new List<Filial>();

        var json = File.ReadAllText(caminhoArquivo);
        var dado = JsonConvert.DeserializeObject<List<Filial>>(json);
        return dado;
    }

    public async Task<bool> UpdateAsync(string id,Filial filial, CancellationToken cancellationToken = default)
    {
        var filiais = await Ler();
        var p = filiais.FindIndex(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        filiais[p] = filial;
        Salvar(filiais);
        return true;
        
    }

    static void Salvar(List<Filial> filial)
    {
        var json = JsonConvert.SerializeObject(filial, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(caminhoArquivo, json);
    }
}
