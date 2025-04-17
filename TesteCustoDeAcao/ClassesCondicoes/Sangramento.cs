using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesCondicoes
{
    public class Sangramento : ICondicaoTemporaria
    {
        public string Nome => "Sangramento";

        public int Duracao { get; set; }

        public int DanoPorAcao { get; set; }

        public Sangramento(int dano, int duracao = 3)
        {
            DanoPorAcao = dano;
            Duracao = duracao;
        }

        public void AplicarEfeito(Personagem jogador)
        {
            jogador.VidaAtual -= DanoPorAcao;
            Console.WriteLine($"{jogador.Nome} sofreu {DanoPorAcao} de Sangramento!");
        }

        public void AplicarEfeito(OInimigo inimigo)
        {
            inimigo.VidaAtual -= DanoPorAcao;
            Console.WriteLine($"{inimigo.Nome} sofreu {DanoPorAcao} de Sangramento!");
        }

        public void Atualizar()
        {
            Duracao--;
        }

        public bool Expirou()
        {
            return Duracao <= 0;
        }
    }
}
