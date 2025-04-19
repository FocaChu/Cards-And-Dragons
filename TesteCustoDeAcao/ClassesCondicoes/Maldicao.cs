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
        public int Duracao { get; set; } = int.MaxValue;

        public int ValorExecucao { get; set; }

        public Maldicao(int valor)
        {
            ValorExecucao = valor;
        }

        public void AplicarEfeito(Personagem jogador)
        {
            if (jogador.VidaAtual <= ValorExecucao)
            {
                jogador.VidaAtual = 0;
                Console.WriteLine($"{jogador.Nome} foi consumido pela Maldição!");
            }
        }

        public void AplicarEfeito(OInimigo inimigo)
        {
            if (inimigo.VidaAtual <= ValorExecucao)
            {
                inimigo.VidaAtual = 0;
                Console.WriteLine($"{inimigo.Nome} foi consumido pela Maldição!");
            }
        }

        public void Fundir(ICondicaoTemporaria nova)
        {
            var novaMaldicao = nova as Maldicao;
            if (novaMaldicao == null) return;

            this.ValorExecucao += novaMaldicao.ValorExecucao;
        }

        public void Atualizar() { } // Não faz nada

        public bool Expirou() => false;
    }

}
