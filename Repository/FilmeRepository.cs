
using System.Data.SqlClient;
using Dapper;
using dotnetDapper.Models;

namespace dotnetDapper.Repository;

public class FilmeRepository : IFilmeRepository
{
    private readonly IConfiguration _configuration;
    private readonly string connectionString;

    public FilmeRepository(IConfiguration configuration)
    {
        this._configuration = configuration;
        connectionString = _configuration.GetConnectionString("SqlConnection");
    }
    public async Task<IEnumerable<FilmeResponse>> BuscarFilesAsync()
    {
        string sql = @"select
                f.id Id,
                f.nome Nome,
                f.ano Ano,
                p.nome Produtora
                from tb_filme f
                inner join tb_produtora p on f.id_produtora = p.id";
        
        using(var con = new SqlConnection(connectionString))
        {
            return await con.QueryAsync<FilmeResponse>(sql);
        }
    }
    public Task<FilmeResponse> BuscarFileAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AdicionaAsync(FilmeResquest resquest)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AtualizarAsync(FilmeResquest resquest, int id)
    {
        throw new NotImplementedException();
    }


    public Task<bool> DeletarAsync(int id)
    {
        throw new NotImplementedException();
    }
}
