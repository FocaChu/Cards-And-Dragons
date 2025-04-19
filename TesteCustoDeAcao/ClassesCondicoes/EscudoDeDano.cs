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

        public int Nivel { get; set; }

        public int Duracao { get; set; }

        public EscudoDeDano(int nivel, int duracao)
        {
            Nivel = nivel;
            Duracao = duracao;
        }

        public override string ToString()
        {
            return $"{this.Nome} Nível: {this.Nivel} / Duração: {this.Duracao}";
        }

        public void AplicarEfeito(Personagem jogador)
        {
            jogador.Escudo += Nivel;
            Console.WriteLine($"{jogador.Nome} ganha um escudo de {Nivel}!");
        }

        public void AplicarEfeito(OInimigo inimigo) { }

        public void Atualizar() => Duracao--;

        public bool Expirou() => Duracao <= 0;
    }

}
