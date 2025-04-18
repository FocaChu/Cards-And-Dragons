using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons
{
    public static class BatalhaController
    {
        public static int SelecionarAlvoOuInventario(Batalha batalha, int option)
        {
            List<OInimigo> inimigos = batalha.Inimigos;
            bool selecionado = false;
            int totalOpcoes = inimigos.Count + 1;

            while (!selecionado)
            {
                Console.Clear();
                Titulo();

                MostrarOsInimigos(option, totalOpcoes, inimigos);

                Console.ResetColor();
                Console.WriteLine("\n"+@"Use ← → para navegar | ENTER para selecionar.");

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

                        if (option < inimigos.Count)
                        {
                            Console.WriteLine($"\nVocê escolheu o inimigo: {inimigos[option].Nome}");
                        }
                        else
                        {
                            Console.WriteLine("\nVocê selecionou o INVENTÁRIO (Jogador).");
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

        public static void MostrarOsInimigos(int option, int totalOpcoes, List<OInimigo> inimigos)
        {
            for (int linha = 0; linha < 10; linha++)
            {
                for (int i = 0; i < totalOpcoes; i++)
                {
                    Console.ForegroundColor = (i == option) ? ConsoleColor.Red : ConsoleColor.Gray;

                    if (i < inimigos.Count)
                    {
                        Console.Write(inimigos[i].Modelo[linha]);
                    }
                    else
                    {
                        if (linha == 5) Console.Write("    [INVENTÁRIO]     ");
                        else Console.Write("                     ");
                    }
                }
                Console.WriteLine();
            }
        }

        private static void Titulo()
        {
            // Caso não tenha acesso à função Titulo() externa,
            // pode colocar algo padrão aqui ou importar de outro lugar
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("==== COMBATE ====");
            Console.ResetColor();
        }

        public static void RecarregarBaralho(Batalha batalha)
        {
            if (batalha.jogador.BaralhoDescarte.Count > 0)
            {
                Console.WriteLine("Reciclando cartas do baralho...");
                batalha.jogador.BaralhoCompra = batalha.jogador.EmbaralharCartas(batalha.jogador.BaralhoDescarte);
                batalha.jogador.BaralhoDescarte.Clear();
            }
            else
            {
                Console.WriteLine("Não há mais cartas para reciclar.");
            }
        }
    }
}
