using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoBancoAda
{

    internal class Banco
    {
        Selecao selecao = new Selecao();

        public void chamarSelecao()
        {
            selecao.AlterarTipoConta();
            selecao.SelecionarOperacao();
        }

    }
}
