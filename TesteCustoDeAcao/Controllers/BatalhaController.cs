using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons.ClassesCondicoes;
using CardsAndDragons.Controllers;
using CardsAndDragons.Inimigos;
using TesteCustoDeAcao;

namespace CardsAndDragons
{
    public static class BatalhaController
    {
        public static int SelecionarAlvoOuInventario(Batalha batalha)
        {
            bool selecionado = false;
            int totalOpcoes = batalha.Inimigos.Count + 1;
            int option = totalOpcoes - 1;

            while (!selecionado)
            {
                Console.Clear();

                MostrarAlvos(batalha, option);

                Console.ResetColor();
                Console.WriteLine("\n" + @"Use ← → para navegar | ENTER para selecionar." + "\n");

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (option > 0) option--;
                        break;

                    case ConsoleKey.RightArrow:
                        if (option < totalOpcoes - 1) option++;
                        break;

                    case ConsoleKey.Enter:
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        if (option < batalha.Inimigos.Count)
                        {
                            Console.WriteLine($"\nVocê escolheu o inimigo: {batalha.Inimigos[option].Nome}");
                        }
                        else
                        {
                            Console.WriteLine("\nVocê selecionou a si mesmo.");
                        }

                        Console.WriteLine("\nAperte ENTER para confirmar, qualquer outra tecla para voltar.");

                        if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                        {
                            selecionado = true;
                        }
                        break;
                }
            }

            return option;
        }

        public static int MenuBatalha(Batalha batalha)
        {
            int acao = 1;
            bool selecionado = false;
            int totalOpcoes = batalha.Inimigos.Count + 1;

            Console.CursorVisible = false;

            string[] opcoesCombate = { "Atacar", "Analisar", "Passar Turno" };

            while (!selecionado)
            {
                Console.Clear();

                MostrarAlvos(batalha, totalOpcoes);

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n" + @"==========  !ESCOLHA SUA AÇÃO!  ==========" + "\n");

                Console.WriteLine("\n====================================\n");
                for (int i = 0; i < opcoesCombate.Length; i++)
                {
                    Console.ForegroundColor = (i + 1 == acao) ? ConsoleColor.DarkGray : ConsoleColor.White;
                    Console.WriteLine($"{(i + 1 == acao ? ">>" : "  ")} {opcoesCombate[i]}");
                }
                Console.ResetColor();
                Console.WriteLine("\n====================================\n");

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (acao > 1) acao--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (acao < opcoesCombate.Length) acao++;
                        break;

                    case ConsoleKey.Enter:
                        selecionado = true;
                        break;
                }
            }
            return acao;
        }

        public static void MostrarAlvos(Batalha batalha, int option)
        {
            int totalOpcoes = batalha.Inimigos.Count + 1;

            Console.WriteLine("\n" + @"=============   !COMBATE!   =============" + "\n");

            for (int linha = 0; linha < 10; linha++)
            {
                for (int i = 0; i < totalOpcoes; i++)
                {
                    Console.ForegroundColor = (i == option) ? ConsoleColor.Red : ConsoleColor.Gray;

                    if (i < batalha.Inimigos.Count)
                    {
                        Console.Write(batalha.Inimigos[i].Modelo[linha]);
                    }
                    else
                    {
                        if (linha == 5) Console.Write($"     -- {batalha.jogador.Nome} --    ");
                        else Console.Write(@"                     ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static List<OInimigo> GerarOsInimigos(int dificuldade)
        {
            List <OInimigo> inimigosDaFase = new List<OInimigo>();
            Random rng = new Random();

            var tiposDeInimigos = InimigoRPGAjudante.ObterTiposDeInimigosDisponiveis();

            // Filtrar inimigos com base na dificuldade
            var inimigosValidos = tiposDeInimigos
                .Select(t => (InimigoRPG)Activator.CreateInstance(t))
                .Where(inimigo => inimigo.Dificuldade < dificuldade && inimigo.Dificuldade > (dificuldade / 4))
                .ToList();

            int chance = rng.Next(100);
            //faz o rng de inimigos aqui
            int quantidadeInimigosNaFase = (chance < 60) ? 3 : 4;

            for (int i = 0; i < quantidadeInimigosNaFase; i++)
            {
                if (inimigosValidos.Count == 0) break;

                int indice = rng.Next(inimigosValidos.Count);

                // cria inimigos aqui
                Type tipo = inimigosValidos[indice].GetType();
                InimigoRPG novoInimigo = (InimigoRPG)Activator.CreateInstance(tipo);

                inimigosDaFase.Add(new OInimigo(novoInimigo));
            }

            return inimigosDaFase;
        }

        public static void AcaoUsarCarta(Batalha batalha)
        {
            int alvo = SelecionarAlvoOuInventario(batalha);

            if (alvo < batalha.Inimigos.Count)
            {
                var inimigoEscolhido = batalha.Inimigos[alvo];
                PersonagemController.EscolherCartaParaUsar(batalha.jogador, inimigoEscolhido);

                InimigoController.VerificarMorte(batalha);
            }
            else
            {
                // Alvo é o próprio jogador
                PersonagemController.EscolherCartaParaUsar(batalha.jogador, null); // null indica "meu alvo sou eu"
            }
        }

        public static void AcaoExibir(Batalha batalha)
        {
            int alvo = SelecionarAlvoOuInventario(batalha);

            if (alvo < batalha.Inimigos.Count)
            {
                InimigoController.ExibirInimigo(batalha.Inimigos[alvo]);
            }
            else
            {
                // Alvo é o próprio jogador
                PersonagemController.ExibirJogador(batalha.jogador, true, true);
            }
        }

        public static void AcaoPassarTurno(Batalha batalha)
        {
            CondicaoController.Checape(batalha);

            Console.ReadKey();

            batalha.TurnoInimigos();

            InimigoController.VerificarMorte(batalha);

            CondicaoController.Checape(batalha.jogador);

        }

        public static int VerificarResultadoRodada(Batalha batalha)
        {
            if (batalha.jogador.VidaAtual == 0)
            {
                return 1;
            }
            if (batalha.Inimigos.Count == 0)
            {
                return 2;
            }
            else
            {
                return 3;

            }
        }

        public static void NovaRodada(Batalha batalha)
        {
            if (batalha.jogador.BaralhoCompra.Count == 0)
            {
                PersonagemController.RecarregarBaralho(batalha.jogador);
            }
            PersonagemController.ComprarCartas(batalha.jogador);

            PersonagemController.RestaurarJogador(batalha.jogador);

        }

    }
}
