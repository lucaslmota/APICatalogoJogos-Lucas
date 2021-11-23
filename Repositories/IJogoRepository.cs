using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APICatalogoJogos_Lucas.Entities;

namespace APICatalogoJogos_Lucas.Repositories
{
    public interface IJogoRepository : IDisposable
    {
        Task<List<Jogo>> Get(int pagina, int quantidade);
        Task<Jogo> GetId(Guid id);
        Task<List<Jogo>> GetName(string nome, string produtora);
        Task Post (Jogo jogo);
        Task Put (Jogo jogo);
        Task Delete (Guid id);
    }
}