using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons.ClassesCondicoes;
using TesteCustoDeAcao;

namespace CardsAndDragons.Controllers
{
    public static class CondicaoController
    {
        public static void AplicarOuAtualizarCondicao(ICondicaoTemporaria nova, List<ICondicaoTemporaria> condicoes)
        {
            var existente = condicoes.FirstOrDefault(c => c.GetType() == nova.GetType());

            if (existente == null)
            {
                condicoes.Add(nova);
            }
            else if (existente is ICondicaoEmpilhavel empilhavel)
            {
                empilhavel.Fundir(nova);
            }
        }


        //Verifica as condições especiais dos inimigos
        public static void Checape(Batalha batalha)
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

                    if (inimigo.Condicoes.Count > 0)
                        for (int i = inimigo.Condicoes.Count - 1; i >= 0; i--)
                        {
                            var condicao = inimigo.Condicoes[i];

                            DefinirCorDaCondicao(condicao.Nome);

                            Console.WriteLine($"{inimigo.Nome} sofre os efeitos de {condicao.Nome}!");

                            condicao.AplicarEfeito(inimigo);
                            condicao.Atualizar();

                            if (condicao.Expirou())
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine($"{inimigo.Nome} não está mais afetado por {condicao.Nome}.");
                                inimigo.Condicoes.RemoveAt(i);
                            }

                            Console.ResetColor();
                        }

                }

                Console.ResetColor();
            }
            InimigoController.VerificarMorte(batalha);
        }

        public static void Checape(Personagem jogador)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("===========   +CHECAPE+   ===========\n");
            Console.ResetColor();

            if (jogador.Condicoes.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\n{jogador.Nome} não está sendo afetado por condições...");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"\n{jogador.Nome} está sendo afetado por condições...");

                if (jogador.Condicoes.Count > 0)
                    for (int i = jogador.Condicoes.Count - 1; i >= 0; i--)
                    {
                        var condicao = jogador.Condicoes[i];

                        DefinirCorDaCondicao(condicao.Nome);

                        Console.WriteLine($"{jogador.Nome} sofre os efeitos de {condicao.Nome}!");

                        condicao.AplicarEfeito(jogador);
                        condicao.Atualizar();

                        if (condicao.Expirou())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine($"{jogador.Nome} não está mais afetado por {condicao.Nome}.");
                            jogador.Condicoes.RemoveAt(i);
                        }

                        Console.ResetColor();
                    }



                Console.ResetColor();
            }

            jogador.BonusDeDano = 0;
            jogador.RedutorDeDano = 0;
            jogador.Escudo = 0;

        }

        public static void ExibirCondicoes(Personagem jogador)
        {
            if (jogador.Condicoes.Count > 0)
                for (int i = jogador.Condicoes.Count - 1; i >= 0; i--)
                {
                    var condicao = jogador.Condicoes[i];

                    DefinirCorDaCondicao(condicao.Nome);

                    Console.WriteLine($"\n{condicao}\n");

                    Console.ResetColor();
                }
        }

        public static void ExibirCondicoes(OInimigo inimigo)
        {
            if (inimigo.Condicoes.Count > 0)
                for (int i = inimigo.Condicoes.Count - 1; i >= 0; i--)
                {
                    var condicao = inimigo.Condicoes[i];

                    DefinirCorDaCondicao(condicao.Nome);

                    Console.WriteLine($"\n{condicao}\n");

                    Console.ResetColor();
                }
        }

        private static void DefinirCorDaCondicao(string nomeCondicao)
        {
            switch (nomeCondicao)
            {
                case "Veneno":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "Sangramento":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "Maldição":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "Congelamento":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "Silêncio":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }

        public static bool VerificarCongelamento(OInimigo inimigo)
        {
            foreach (var condicao in inimigo.Condicoes)
            {
                if (condicao is Congelamento)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static bool VerificarSilencio(List<ICondicaoTemporaria> condicoes)
        {
            foreach (var condicao in condicoes)
            {
                if (condicao is Silencio)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
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

        public static void VerificarSangramento(Personagem jogador)
        {
            foreach (var condicao in jogador.Condicoes)
            {
                if (condicao is Sangramento sangramento)
                {
                    sangramento.AplicarEfeito(jogador);
                }
            }
        }
    }
}
