using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APICatalogoJogos_Lucas.InputModel;
using APICatalogoJogos_Lucas.ViewModel;

namespace APICatalogoJogos_Lucas.Service
{
    public interface IJogoService : IDisposable
    {
        Task<List<JogoViewModel>> Get(int pagina, int quantidade);
        Task<JogoViewModel> GetId(Guid id);
        Task<JogoViewModel> Post(JogoInputModel jogo);
        Task Put(Guid id, JogoInputModel jogo);
        Task Patch(Guid id, double preco);
        Task Delete(Guid id);
    }
}