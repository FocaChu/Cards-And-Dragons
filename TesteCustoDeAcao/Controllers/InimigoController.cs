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
            Console.WriteLine($"\n{inimigo}\n");

            CondicaoController.ExibirCondicoes(inimigo);

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
