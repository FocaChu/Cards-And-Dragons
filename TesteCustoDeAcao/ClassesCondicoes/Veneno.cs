using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesCondicoes
{ 
    public class Veneno : ICondicaoTemporaria
    {
        public string Nome => "Veneno";
        public int Duracao { get; set; }
        public int DanoPorTurno { get; set; }

        public Veneno(int dano, int duracao = 3)
        {
            DanoPorTurno = dano;
            Duracao = duracao;
        }

        public void AplicarEfeito(Personagem jogador)
        {
            jogador.VidaAtual -= DanoPorTurno;
            Console.WriteLine($"{jogador.Nome} sofre {DanoPorTurno} de Veneno!");
        }

        public void AplicarEfeito(OInimigo inimigo)
        {
            inimigo.VidaAtual -= DanoPorTurno;
            Console.WriteLine($"{inimigo.Nome} sofre {DanoPorTurno} de Veneno!");
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
