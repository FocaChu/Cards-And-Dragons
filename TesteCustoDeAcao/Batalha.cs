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

        public void OrganizarJogador(Personagem jogador)
        {

        }

        public void EscolherCartaParaUsar(OInimigo inimigoEscolhido)
        {
            Console.Clear();
            Console.WriteLine($"\n===== Cartas na Mão =====\n");

            for (int i = 0; i < this.jogador.Mao.Count; i++)
            {
                var carta = this.jogador.Mao[i];
                Console.WriteLine($"{i + 1}. {carta.Nome} - {carta.Descricao}");
            }

            Console.WriteLine("\nEscolha uma carta para usar (ou 0 para cancelar):");

            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= this.jogador.Mao.Count)
            {
                this.jogador.UsarCarta(escolha - 1, inimigoEscolhido);
            }
            else
            {
                Console.WriteLine("Ação cancelada.");
            }

            Console.ReadKey();
        }

        public void ChecapeInimigos()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("===========   +CHECAPE+   ===========\n");
            Console.ResetColor();

            foreach (var inimigo in Inimigos)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\n{inimigo.Nome} está sendo afetado por condições...");
                Console.ResetColor();

                inimigo.AtualizarCondicoes();

                InimigoMorreu();
            }
        }

        public void InimigoMorreu()
        {
            List<OInimigo> inimigosMortos = new List<OInimigo>();

            foreach (var inimigo in Inimigos)
            {
                
                if (inimigo.VidaAtual <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{inimigo.Nome} foi derrotado!");
                    Console.ResetColor();

                    int ouroGanho = (this.jogador.Especie.NomeEspecie == "Anão") ? 10 : 5;
                    jogador.Ouros += ouroGanho;
                    Console.WriteLine($"Você ganhou {ouroGanho} ouros. Total: {jogador.Ouros}");

                    jogador.ContabilizarXp(inimigo);

                    inimigosMortos.Add(inimigo);
                }
            }
            foreach (var morto in inimigosMortos)
            {
                Inimigos.Remove(morto);
            }
        }



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
                System.Threading.Thread.Sleep(900); // Tempo pra ler o ataque}

                rodadaAtual++;
            }
        }

        public void ExibirInimigo(OInimigo inimigo)
        {
            Console.WriteLine(inimigo);
            for (int linha = 0; linha < 10; linha++)
            {
                // Define a cinza 
                Console.ForegroundColor = ConsoleColor.Gray;

                // Pega a linha do modelo atual do inimigo
                string linhaModelo = inimigo.Modelo[linha];

                Console.Write(linhaModelo);

                Console.WriteLine();
                // pula pra próxima linha do desenho
            }
        }

        public void RestaurarJogador()
        {
            this.jogador.VidaAtual = this.jogador.VidaAtual + this.jogador.Regeneracao;
            this.jogador.ManaAtual = this.jogador.ManaMax;
            this.jogador.StaminaAtual = this.jogador.StaminaMax;
        }

        public bool BatalhaTerminou()
        {
            return jogador.VidaAtual <= 0 || Inimigos.Count == 0;
        }
    }
}
