using System;

namespace APICatalogoJogos_Lucas.Exceptions
{
    public class JogoNaoCadastradoException :Exception
    {
        public JogoNaoCadastradoException()
            :base("Este jogo não está cadastrado")
        {}
    }
}