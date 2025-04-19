using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons;
using CardsAndDragons.Inimigos;

namespace TesteCustoDeAcao
{
    public class Batalha
    {
        public Personagem jogador { get; set; }

        public List<OInimigo> Inimigos { get; set; }

        private int rodadaAtual = 1;

        public Batalha(Personagem jogadorAtual, List<OInimigo> inimigosDaFase)
        {
            jogador = jogadorAtual;
            Inimigos = inimigosDaFase;
        }

        //Faz os inimigos atacarem o jogador
        public void TurnoInimigos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("========== !TURNO DOS INIMIGOS! ==========\n");
            Console.ResetColor();

            foreach (var inimigo in Inimigos)
            {
                 Console.WriteLine($"\n{inimigo.Nome} está se preparando para agir...\n");
                System.Threading.Thread.Sleep(300); // Delayzinho dramático

                inimigo.RealizarTurno(jogador, rodadaAtual);

                Console.WriteLine();
                System.Threading.Thread.Sleep(900); // Tempo pra ler o ataque

                
            }
            rodadaAtual++;
        }
    }
}
