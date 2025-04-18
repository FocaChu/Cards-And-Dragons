using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons;

namespace TesteCustoDeAcao
{
    public interface ICartaUsavel
    {
        string Nome { get; }

        string Descricao { get; }

        int CustoVida { get; }

        int CustoMana { get; }

        int CustoStamina { get; }

        int CustoOuro { get; }

        List<string> Modelo { get; }

        void Usar(Personagem jogador, OInimigo alvo);
    }

}
