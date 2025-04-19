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
        public int Duracao { get; set; }
        public int Reducao { get; set; }

        public RedutorDeDano(int reducao, int duracao)
        {
            Reducao = reducao;
            Duracao = duracao;
        }

        public void AplicarEfeito(Personagem jogador)
        {
            jogador.RedutorDeDano += Reducao;
            Console.WriteLine($"{jogador.Nome} reduz {Reducao} de dano recebido!");
        }

        public void AplicarEfeito(OInimigo inimigo) { }

        public void Atualizar() => Duracao--;

        public bool Expirou() => Duracao <= 0;
    }

}
