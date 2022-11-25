using dotnetDapper.Models;

namespace dotnetDapper.Repository;

public interface IFilmeRepository
{
    Task<IEnumerable<FilmeResponse>> BuscarFilesAsync();
    Task<FilmeResponse> BuscarFileAsync(int id);
    Task<bool> AdicionaAsync(FilmeRequest resquest);
    Task<bool> AtualizarAsync(FilmeRequest resquest, int id);

    Task<bool> DeletarAsync(int id);
    
}