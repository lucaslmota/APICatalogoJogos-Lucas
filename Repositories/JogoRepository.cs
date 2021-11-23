using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APICatalogoJogos_Lucas.Entities;

namespace APICatalogoJogos_Lucas.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<List<Jogo>> Get(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task<Jogo> GetId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Jogo>> GetName(string nome, string produtora)
        {
            throw new NotImplementedException();
        }

        public Task Post(Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public Task Put(Jogo jogo)
        {
            throw new NotImplementedException();
        }
    }
}