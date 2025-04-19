using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons.ClassesCondicoes;
using TesteCustoDeAcao;

namespace CardsAndDragons.Controllers
{
    public static class InimigoController
    {
        

        public static void ExibirInimigo(OInimigo inimigo)
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

        //Verifica as condições especiais dos inimigos
        public static void ChecapeInimigos(Batalha batalha)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("===========   +CHECAPE+   ===========\n");
            Console.ResetColor();

            foreach (var inimigo in batalha.Inimigos)
            {
                if (inimigo.Condicoes.Count <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"\n{inimigo.Nome} não está sendo afetado por condições...");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\n{inimigo.Nome} está sendo afetado por condições...");
                }

                Console.ResetColor();

                inimigo.AtualizarCondicoes();
            }
            VerificarMorte(batalha);
        }

        public static void VerificarSangramento(OInimigo inimigo)
        {
            foreach (var condicao in inimigo.Condicoes)
            {
                if (condicao is Sangramento sangramento)
                {
                    sangramento.AplicarEfeito(inimigo);
                }
            }
        }

        //public static void VerificarMaldicao(Personagem personagem)
        //{
        //    foreach (var condicao in personagem.Condicoes)
        //    {
        //        if (condicao is Maldicao maldicao)
        //        {
        //            maldicao.AplicarEfeito(personagem);
        //        }
        //    }
        //}

        //verifica se algum inimigo morreu
        public static void VerificarMorte(Batalha batalha)
        {
            List<OInimigo> inimigosMortos = new List<OInimigo>();

            foreach (var inimigo in batalha.Inimigos)
            {

                if (inimigo.VidaAtual <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{inimigo.Nome} foi derrotado!");
                    Console.ResetColor();

                    int ouroGanho = (batalha.jogador.Especie.NomeEspecie == "Anão") ? 10 : 5;
                    batalha.jogador.Ouros += ouroGanho;
                    Console.WriteLine($"Você ganhou {ouroGanho} ouros. Total: {batalha.jogador.Ouros}");

                    batalha.jogador.ContabilizarXp(inimigo);

                    inimigosMortos.Add(inimigo);
                }
            }
            foreach (var morto in inimigosMortos)
            {
                batalha.Inimigos.Remove(morto);
            }
        }
    }
}
