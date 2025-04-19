using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesCondicoes
{
    public class EscudoDeDano : ICondicaoTemporaria
    {
        public string Nome => "Escudo";
        public int Duracao { get; set; }
        public int ValorEscudo { get; set; }

        public EscudoDeDano(int valor, int duracao)
        {
            ValorEscudo = valor;
            Duracao = duracao;
        }

        public void AplicarEfeito(Personagem jogador)
        {
            jogador.Escudo += ValorEscudo;
            Console.WriteLine($"{jogador.Nome} ganha um escudo de {ValorEscudo}!");
        }

        public void AplicarEfeito(OInimigo inimigo) { }

        public void Atualizar() => Duracao--;

        public bool Expirou() => Duracao <= 0;
    }

}
