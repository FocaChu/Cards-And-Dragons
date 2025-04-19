using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesCondicoes
{
    public class RedutorDeDano : ICondicaoTemporaria
    {
        public string Nome => "Redutor de Dano";

        public int Nivel { get; set; }

        public int Duracao { get; set; }

        public RedutorDeDano(int nivel, int duracao)
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
            jogador.RedutorDeDano += Nivel;
            Console.WriteLine($"{jogador.Nome} reduz {Nivel} de dano recebido!");
        }

        public void AplicarEfeito(OInimigo inimigo) { }

        public void Atualizar() => Duracao--;

        public bool Expirou() => Duracao <= 0;
    }

}
