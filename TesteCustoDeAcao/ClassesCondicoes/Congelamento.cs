using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesCondicoes
{
    public class Congelamento : ICondicaoTemporaria
    {
        public string Nome => "Congelamento";

        public int Nivel { get; set; }

        public int Duracao { get; set; }

        public Congelamento()
        {
            Nivel = 1;
            Duracao = 1;
        }

        public override string ToString()
        {
            return $"{this.Nome} Nível: {this.Nivel} / Duração: {this.Duracao}";
        }

        public void AplicarEfeito(Personagem jogador)
        {
        }

        public void AplicarEfeito(OInimigo inimigo)
        {
            Console.WriteLine($"{inimigo.Nome} foi congelado!");
        }

        public void Atualizar() => Duracao--;

        public bool Expirou() => Duracao <= 0;
    }


}
