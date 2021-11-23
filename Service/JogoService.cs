using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICatalogoJogos_Lucas.Entities;
using APICatalogoJogos_Lucas.Exceptions;
using APICatalogoJogos_Lucas.InputModel;
using APICatalogoJogos_Lucas.Repositories;
using APICatalogoJogos_Lucas.ViewModel;

namespace APICatalogoJogos_Lucas.Service
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        public async Task<List<JogoViewModel>> Get(int pagina, int quantidade)
        {
            var jogos = await _jogoRepository.Get(pagina, quantidade);

            return jogos.Select(jogo => new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            })
                               .ToList();
        }

        public async Task<JogoViewModel> GetId(Guid id)
        {
            var jogo = await _jogoRepository.GetId(id);

            if (jogo == null)
                return null;

            return new JogoViewModel
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task<JogoViewModel> Post(JogoInputModel jogo)
        {
            var entidadeJogo = await _jogoRepository.GetName(jogo.Nome, jogo.Produtora);

            if (entidadeJogo.Count > 0)
                throw new JogoJaCadastradoException();

            var jogoInsert = new Jogo
            {
                Id = Guid.NewGuid(),
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };

            await _jogoRepository.Post(jogoInsert);

            return new JogoViewModel
            {
                Id = jogoInsert.Id,
                Nome = jogo.Nome,
                Produtora = jogo.Produtora,
                Preco = jogo.Preco
            };
        }

        public async Task Delete(Guid id)
        {
            var jogo = await _jogoRepository.GetId(id);

            if (jogo == null)
                throw new JogoNaoCadastradoException();

            await _jogoRepository.Delete(id);
        }

        public void Dispose()
        {
            _jogoRepository?.Dispose();
        }

        public async Task Patch(Guid id, double preco)
        {
            var entidadeJogo = await _jogoRepository.GetId(id);

            if (entidadeJogo == null)
                throw new JogoNaoCadastradoException();

            entidadeJogo.Preco = preco;

            await _jogoRepository.Put(entidadeJogo);
        }

        public async Task Put(Guid id, JogoInputModel jogo)
        {
            var entidadeJogo = await _jogoRepository.GetId(id);

            if (entidadeJogo == null)
                throw new JogoNaoCadastradoException();

            entidadeJogo.Nome = jogo.Nome;
            entidadeJogo.Produtora = jogo.Produtora;
            entidadeJogo.Preco = jogo.Preco;

            await _jogoRepository.Put(entidadeJogo);
        }
    }
}