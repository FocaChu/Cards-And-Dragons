using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesCondicoes
{
    public interface ICondicaoTemporaria
    {
        string Nome { get; }

        int Duracao { get; set; }

        void AplicarEfeito(Personagem jogador);

        void AplicarEfeito(OInimigo inimigo);

        void Atualizar();

        bool Expirou();
    }
}
