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

        public List<OInimigo> Inimigos {  get; set; }

        private int rodadaAtual = 1;

        public Batalha(Personagem jogadorAtual, List<OInimigo> inimigosDaFase)
        {
            jogador = jogadorAtual;
            Inimigos = inimigosDaFase;
        }

        public void OrganizarJogador(Personagem jogador)
        {

        }

        public void AtacarInimigo(OInimigo inimigoEscolhido)
        {
            // Remove inimigo se morreu
            if (inimigoEscolhido.VidaAtual <= 0)
            {
                Console.WriteLine($"{inimigoEscolhido.Nome} foi derrotado!");

                //this.jogador.Ouros = this.jogador.Ouros + 5;
                this.jogador.Ouros = (this.jogador.Especie.NomeEspecie == "Anão") ? this.jogador.Ouros = this.jogador.Ouros + 10 : this.jogador.Ouros = this.jogador.Ouros + 5;

                Console.WriteLine($"Ouro: {this.jogador.Ouro}");

                this.jogador.ContabilizarXp(inimigoEscolhido);

                Inimigos.Remove(inimigoEscolhido);
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
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\n{inimigo.Nome} está sendo afetado por condições...");
                Console.ResetColor();

                inimigo.AtualizarCondicoes();

                Console.WriteLine($"\n{inimigo.Nome} está se preparando para agir...\n");
                System.Threading.Thread.Sleep(500); // Delayzinho dramático

                inimigo.RealizarTurno(jogador, rodadaAtual);

                Console.WriteLine();
                System.Threading.Thread.Sleep(1000); // Tempo pra ler o ataque
            }

            rodadaAtual++;
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

        public static void ExibirJogador(Personagem jogador)
        {
            Console.WriteLine($"\n{jogador}\n");

            for (int linha = 0; linha < 10; linha++)
            {

                for (int i = 0; i < jogador.BaralhoCompleto.Count; i++)
                {
                    // Define a cor branca
                    Console.ForegroundColor = ConsoleColor.White;

                    // Pega a linha do modelo atual da carta
                    string linhaModelo = jogador.BaralhoCompleto[i].Modelo[linha];

                    Console.Write(linhaModelo);
                }

                Console.WriteLine();
                // pula pra próxima linha do desenho
            }
        }

        public static void MostrarCartasNaMao(Personagem jogador)
        {
            Console.Clear();
            Console.WriteLine($"\n===== Cartas de {jogador.Nome} =====\n");

            if (jogador.BaralhoCompleto.Count == 0)
            {
                Console.WriteLine("Você não tem cartas.");
                return;
            }

            int index = 1;
            foreach (var carta in jogador.BaralhoCompleto)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{index++} - {carta.Nome}");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"  {carta.Descricao}");
                Console.WriteLine($"  Custo: Vida {carta.CustoVida}, Mana {carta.CustoMana}, Stamina {carta.CustoStamina}, Ouro {carta.CustoOuro}\n");
            }

            Console.ResetColor();
            Console.WriteLine("Pressione qualquer tecla para voltar.");
            Console.ReadKey();
        }

        public static void EscolherCartaParaUsar(Personagem jogador, List<OInimigo> alvos)
        {
            Console.Clear();
            Console.WriteLine($"\n===== Cartas na Mão =====\n");

            for (int i = 0; i < jogador.Mao.Count; i++)
            {
                var carta = jogador.Mao[i];
                Console.WriteLine($"{i + 1}. {carta.Nome} - {carta.Descricao}");
            }

            Console.WriteLine("\nEscolha uma carta para usar (ou 0 para cancelar):");

            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= jogador.Mao.Count)
            {
                jogador.UsarCarta(escolha - 1, alvos);
            }
            else
            {
                Console.WriteLine("Ação cancelada.");
            }

            Console.ReadKey();
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
