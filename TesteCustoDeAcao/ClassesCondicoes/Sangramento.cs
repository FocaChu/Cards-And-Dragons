using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesCondicoes
{
    public class Sangramento : ICondicaoEmpilhavel
    {
        public string Nome => "Sangramento";

        public int Nivel { get; set; }

        public int Duracao { get; set; }

        public Sangramento(int nivel, int duracao)
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
            jogador.VidaAtual -= Nivel;
            Console.WriteLine($"{jogador.Nome} sofre {Nivel} de dano por Sangramento!");
        }

        public void AplicarEfeito(OInimigo inimigo)
        {
            inimigo.VidaAtual -= Nivel;
            Console.WriteLine($"{inimigo.Nome} sofre {Nivel} de dano por Sangramento!");
        }

        public void Atualizar()
        {
            Duracao--;
            Nivel--;
        }

        public bool Expirou()
        {
            return Duracao <= 0;
        }

        public void Fundir(ICondicaoTemporaria nova)
        {
            var novoSangramento = nova as Sangramento;
            if (novoSangramento == null) return;

            this.Nivel += novoSangramento.Nivel;
            this.Duracao = Math.Max(this.Duracao, novoSangramento.Duracao);
        }
    }

}
