using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesCondicoes
{
    public class Maldicao : ICondicaoTemporaria
    {
        public string Nome => "Maldição";

        public int Duracao { get; set; }

        public int ValorMaldito { get; set; }

        public Maldicao(int valor, int duracao = 5)
        {
            ValorMaldito = valor;
            Duracao = duracao;
        }

        public void AplicarEfeito(Personagem jogador)
        {
            if (jogador.VidaAtual == ValorMaldito)
            {
                jogador.VidaAtual = 0;
                Console.WriteLine($"{jogador.Nome} foi executado pela Maldição!");
            }
        }

        public void AplicarEfeito(OInimigo inimigo)
        {
            if (inimigo.VidaAtual == ValorMaldito)
            {
                inimigo.VidaAtual = 0;
                Console.WriteLine($"{inimigo.Nome} foi executado pela Maldição!");
            }
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
