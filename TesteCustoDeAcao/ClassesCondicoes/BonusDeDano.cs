using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesCondicoes
{
    public class BonusDeDano : ICondicaoTemporaria
    {
        public string Nome => "Bônus de Dano";
        public int Duracao { get; set; }
        public int Aumento { get; set; }

        public BonusDeDano(int aumento, int duracao)
        {
            Aumento = aumento;
            Duracao = duracao;
        }

        public void AplicarEfeito(Personagem jogador)
        {
            jogador.BonusDeDano += Aumento;
            Console.WriteLine($"{jogador.Nome} recebe +{Aumento} de dano!");
        }

        public void AplicarEfeito(OInimigo inimigo) { } // Não se aplica a inimigo

        public void Atualizar()
        {
            Duracao--;
        }

        public bool Expirou() => Duracao <= 0;
    }

}
