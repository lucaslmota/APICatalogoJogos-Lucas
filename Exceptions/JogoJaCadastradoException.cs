using System;

namespace APICatalogoJogos_Lucas.Exceptions
{
    public class JogoJaCadastradoException :Exception
    {
         public JogoJaCadastradoException()
            : base("Este já jogo está cadastrado")
        { }
    }
}