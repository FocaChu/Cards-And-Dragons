using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesCondicoes
{
    public class Maldicao : ICondicaoEmpilhavel
    {
        public string Nome => "Maldição";


        public int Nivel { get; set; }

        public int Duracao { get; set; } = int.MaxValue;

        public Maldicao(int nivel)
        {
            Nivel = nivel;
        }

        public override string ToString()
        {
            return $"{this.Nome} Nível: {this.Nivel} / Duração: ???";
        }

        public void AplicarEfeito(Personagem jogador)
        {
            if (jogador.VidaAtual <= Nivel)
            {
                jogador.VidaAtual = 0;
                Console.WriteLine($"{jogador.Nome} foi consumido pela Maldição!");
            }
        }

        public void AplicarEfeito(OInimigo inimigo)
        {
            if (inimigo.VidaAtual <= Nivel)
            {
                inimigo.VidaAtual = 0;
                Console.WriteLine($"{inimigo.Nome} foi consumido pela Maldição!");
            }
        }

        public void Fundir(ICondicaoTemporaria nova)
        {
            var novaMaldicao = nova as Maldicao;
            if (novaMaldicao == null) return;

            this.Nivel += novaMaldicao.Nivel;
        }

        public void Atualizar() { } // Não faz nada

        public bool Expirou() => false;
    }

}
