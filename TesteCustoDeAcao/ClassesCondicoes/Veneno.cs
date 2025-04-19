using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesCondicoes
{
    public class Veneno : ICondicaoEmpilhavel
    {
        public string Nome => "Veneno";

        public int Nivel { get; set; }

        public int Duracao { get; set; }

        public Veneno(int nivel, int duracao)
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
            Console.WriteLine($"{jogador.Nome} sofre {Nivel} de Veneno!");
        }

        public void AplicarEfeito(OInimigo inimigo)
        {
            inimigo.VidaAtual -= Nivel;
            Console.WriteLine($"{inimigo.Nome} sofre {Nivel} de Veneno!");
        }

        public void Atualizar() => Duracao--;

        public bool Expirou() => Duracao <= 0;

        public void Fundir(ICondicaoTemporaria nova)
        {
            var novoVeneno = nova as Veneno;
            if (novoVeneno == null) return;

            this.Nivel += novoVeneno.Nivel;
            this.Duracao = Math.Max(this.Duracao, novoVeneno.Duracao);
        }
    }


}
