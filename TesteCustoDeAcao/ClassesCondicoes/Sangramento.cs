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
        public int DanoPorEvento { get; set; }

        public Sangramento(int dano, int duracao = 3)
        {
            DanoPorEvento = dano;
            Duracao = duracao;
        }

        public void AplicarEfeito(Personagem jogador)
        {
            jogador.VidaAtual -= DanoPorEvento;
            Console.WriteLine($"{jogador.Nome} sofre {DanoPorEvento} de dano por Sangramento!");
        }

        public void AplicarEfeito(OInimigo inimigo)
        {
            inimigo.VidaAtual -= DanoPorEvento;
            Console.WriteLine($"{inimigo.Nome} sofre {DanoPorEvento} de dano por Sangramento!");
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
