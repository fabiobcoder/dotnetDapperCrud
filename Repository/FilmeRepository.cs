
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
        _configuration = configuration;
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
        
        using var con = new SqlConnection(connectionString);
            return await con.QueryAsync<FilmeResponse>(sql);
        
    }
    public async Task<FilmeResponse> BuscarFileAsync(int id)
    {
        string sql = @"select
                f.id Id,
                f.nome Nome,
                f.ano Ano,
                p.nome Produtora
                from tb_filme f
                inner join tb_produtora p on f.id_produtora = p.id
                where f.id = @id";

        using var con = new SqlConnection(connectionString);
            return await con.QueryFirstOrDefaultAsync<FilmeResponse>(sql, new { Id = id});
    }

    public async Task<bool> AdicionaAsync(FilmeRequest request)
    {
                string sql = @"INSERT INTO tb_filme(nome,ano,id_produtora)
                                VALUES (@Nome, @Ano, @ProdutoraId)";

        using var con = new SqlConnection(connectionString);
            return await con.ExecuteAsync(sql, request) > 0 ;
    }

    public async Task<bool> AtualizarAsync(FilmeRequest request, int id)
    {
        string sql = @"UPDATE tb_filme SET
                        nome = @Nome,
                        ano = @Ano                        
                        WHERE id = @Id";
        
        var parametros = new DynamicParameters();
        parametros.Add("Ano", request.Ano);
        parametros.Add("Nome", request.Nome);
        parametros.Add("Id", id);

        using var con = new SqlConnection(connectionString);
            return await con.ExecuteAsync(sql, parametros) > 0 ;
    }


    public async Task<bool> DeletarAsync(int id)
    {
        string sql = @"DELETE FROM tb_filme               
                        WHERE id = @Id";
        
        using var con = new SqlConnection(connectionString);
            return await con.ExecuteAsync(sql, new { Id = id}) > 0 ;
    }
}
