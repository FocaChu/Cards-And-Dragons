using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons.ClassesCondicoes;
using CardsAndDragons.Controllers;
using TesteCustoDeAcao;

namespace CardsAndDragons
{
    public static class PersonagemController
    {

        #region Cria o Personagem
        public static EspecieRPG SelecionarEspecie()
        {
            //mostra todas as especies
            var especiesDisponiveis = EspecieRPGAjudante.ObterTodasAsEspeciesDisponiveis();

            //variaveis que fazem a seleção funcionar
            int opcaoSelecionada = 0;
            bool selecionado = false;
            bool voltar = false;

            //tira o cursor da tela
            Console.CursorVisible = false;

            //manter o menu funcionando em quanto vc n selecionar algo
            while (!selecionado)
            {
                Console.Clear();

                Console.WriteLine("\n========== CRIAÇÃO DE PERSONAGEM ==========\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nEscolha sua Espécie:\n");

                //é oque mostra o menu na tela com base no EspecieHelper e permite vc ver qual especie vc ta selecionando
                Console.WriteLine("\n====================================\n");
                for (int i = 0; i < especiesDisponiveis.Count; i++)
                {
                    if (i == opcaoSelecionada)
                    {

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($">> {especiesDisponiveis[i].NomeEspecie} \n- {especiesDisponiveis[i].DescricaoEspecie}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"   {especiesDisponiveis[i].NomeEspecie}");
                    }

                }
                Console.ResetColor();
                Console.WriteLine("\n====================================\n");
                //pega a tecla que vc apertou pro switch
                ConsoleKeyInfo tecla = Console.ReadKey(true);

                switch (tecla.Key)
                {
                    //se cliclar pra cima sobe pra opção de cima e ajusta o valor pra acompanhar ela na lista
                    case ConsoleKey.UpArrow:
                        if (opcaoSelecionada > 0)
                            opcaoSelecionada--;
                        break;
                    //se clicar pra baixo desce pra opção de baixo e ajusta o valor pra combinar com ela na lista
                    case ConsoleKey.DownArrow:
                        if (opcaoSelecionada < especiesDisponiveis.Count - 1)
                            opcaoSelecionada++;
                        break;

                    case ConsoleKey.Enter:
                        selecionado = true;
                        break;
                    //Ao clicar em enter ele para o codigo e pega a especie correspondente ao valor escolhido(que é definido por opcaoSelecionada)

                    case ConsoleKey.Escape:
                        selecionado = true;
                        voltar = true;
                        break;
                        //Serve para encerrar o codigo, mas n deixar ele continuar e forçar ele a voltar.
                }
            }

            //se vc cliclou enter vem pra ca normal e devolve a especie escolhida
            if (voltar == false)
            {
                Console.Clear();
                Console.WriteLine("\n====================================\n");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Você escolheu a Espécie: {especiesDisponiveis[opcaoSelecionada].NomeEspecie}");
                Console.ResetColor();
                Console.WriteLine("\n====================================\n");
                Console.ReadKey();
                Console.Clear();

                return especiesDisponiveis[opcaoSelecionada];
            }
            //se vc clicou Esc, ele vai devolver um valor nulo
            else
            {
                return null;
            }
        }

        public static ClasseRPG EscolherClasse()
        {
            //Mostra todas as classes
            var classesDisponiveis = ClasseRPGAjudante.ObterTodasAsClassesDisponiveis();

            //variaveis que fazem a seleção funcionar
            int opcaoSelecionada = 0;
            bool selecionado = false;
            bool voltar = false;

            //tira o cursor da tela
            Console.CursorVisible = false;

            //manter o menu funcionando em quanto vc n selecionar algo
            while (!selecionado)
            {
                Console.Clear();

                Console.WriteLine("\n========== CRIAÇÃO DE PERSONAGEM ==========\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nEscolha sua Classe:\n");

                //é oque mostra o menu na tela com base no ClasseHelper e permite vc ver qual especie vc ta selecionando
                Console.WriteLine("\n====================================\n");
                for (int i = 0; i < classesDisponiveis.Count; i++)
                {
                    if (i == opcaoSelecionada)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($">> {classesDisponiveis[i].NomeClasse} \n- {classesDisponiveis[i].DescricaoClasse}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"   {classesDisponiveis[i].NomeClasse}");
                    }
                }
                Console.ResetColor();
                Console.WriteLine("\n====================================\n");

                //pega a tecla que vc apertou pro switch
                ConsoleKeyInfo tecla = Console.ReadKey(true);

                switch (tecla.Key)
                {
                    //se cliclar pra cima sobe pra opção de cima e ajusta o valor pra acompanhar ela na lista
                    case ConsoleKey.UpArrow:
                        if (opcaoSelecionada > 0)
                            opcaoSelecionada--;
                        break;

                    //se clicar pra baixo desce pra opção de baixo e ajusta o valor pra combinar com ela na lista
                    case ConsoleKey.DownArrow:
                        if (opcaoSelecionada < classesDisponiveis.Count - 1)
                            opcaoSelecionada++;
                        break;

                    case ConsoleKey.Enter:
                        selecionado = true;
                        break;
                    //Ao clicar em enter ele para o codigo e pega a especie correspondente ao valor escolhido(que é definido por opcaoSelecionada)

                    case ConsoleKey.Escape:
                        selecionado = true;
                        voltar = true;
                        break;
                        //Serve para encerrar o codigo, mas n deixar ele continuar e forçar ele a voltar.
                }
            }

            //se vc cliclou enter vem pra ca normal e devolve a especie escolhida
            if (voltar == false)
            {
                Console.Clear();
                Console.WriteLine("\n====================================\n");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Você escolheu a Classe: {classesDisponiveis[opcaoSelecionada].NomeClasse}");
                Console.ResetColor();
                Console.WriteLine("\n====================================\n");
                Console.ReadKey();
                Console.Clear();

                return classesDisponiveis[opcaoSelecionada];
            }
            //se vc clicou Esc, ele vai devolver um valor nulo
            else
            {
                return null;
            }
        }

        public static Personagem CriarPersonagem(EspecieRPG especieEscolhida, ClasseRPG classeEscolhida)
        {
            string nome = "";
            Console.WriteLine("\n========== CRIAÇÃO DE PERSONAGEM ==========\n");
            while (nome == null || nome == string.Empty)
            {
                Console.Write("\nNomeie o seu personagem: ");
                nome = Console.ReadLine();
            }
            Personagem jogador = new Personagem(nome, especieEscolhida, classeEscolhida);
            return jogador;
        }

        #endregion

        #region Exibi o Personagem, suas Cartas e seus Itens

        //Mostrra o jogador e seus status, opcionalmente seu baralho
        public static void ExibirJogador(Personagem jogador, bool exibirCondicoes, bool exibirBaralho)
        {
            Console.WriteLine($"\n{jogador}\n");

            if (exibirCondicoes) CondicaoController.ExibirCondicoes(jogador);

            if (exibirBaralho) MostrarBaralhoCompleto(jogador);
            
        }

        //Mostra todas as cartas que tem no baralho do jogador
        public static void MostrarBaralhoCompleto(Personagem jogador)
        {
            for (int linha = 0; linha < 10; linha++)
            {
                for (int i = 0; i < jogador.BaralhoCompleto.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.Write(jogador.BaralhoCompleto[i].Modelo[linha]);

                }
                Console.WriteLine();
            }
        }

        //Mostra todas aws cartas que o jogador tem na mão
        public static void MostrarCartasNaMao(Personagem jogador, int option)
        {
            Console.Clear();
            Console.WriteLine($"\n===== Cartas de {jogador.Nome} =====\n");

            if (jogador.Mao.Count == 0)
            {
                Console.WriteLine("\nVocê não tem cartas.\n");
                return;
            }
            for (int linha = 0; linha < 10; linha++)
            {
                for (int i = 0; i < jogador.Mao.Count; i++)
                {
                    Console.ForegroundColor = (i == option) ? ConsoleColor.Red : ConsoleColor.Gray;

                    Console.Write(jogador.Mao[i].Modelo[linha]);

                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\nCarta - {jogador.Mao[option].Nome} \nEfeito - {jogador.Mao[option].Descricao}\n");
            Console.WriteLine("Custo:");
            if (jogador.Mao[option].CustoVida > 0) Console.WriteLine($" - {jogador.Mao[option].CustoVida} de Vida");
            if (jogador.Mao[option].CustoStamina > 0) Console.WriteLine($" - {jogador.Mao[option].CustoStamina} de Stamina");
            if (jogador.Mao[option].CustoMana > 0) Console.WriteLine($" - {jogador.Mao[option].CustoMana} de Mana");
            if (jogador.Mao[option].CustoOuro > 0) Console.WriteLine($" - {jogador.Mao[option].CustoOuro} de Ouro");
            Console.WriteLine("\n");
        }

        #endregion

        #region Gerencia as Cartas do Jogador

        public static void EscolherCartaParaUsar(Personagem jogador, OInimigo inimigoEscolhido)
        {
            Console.Clear();
            Console.WriteLine($"\n===== Cartas na Mão =====\n");

            int option = 0;
            int escolha = SelecionarCarta(jogador, option);

            if (escolha >= 0)
            {
                jogador.UsarCarta(escolha, inimigoEscolhido);
            }
            else
            {
                Console.WriteLine("\nAção cancelada.");
                Console.ReadKey();
            }
        }

        public static int SelecionarCarta(Personagem jogador, int option)
        {
            bool selecionado = false;
            int totalOpcoes = jogador.Mao.Count;
            bool voltar = false;

            while (!selecionado)
            {
                Console.Clear();

                Console.WriteLine("=============   !COMBATE!   =============");

                MostrarCartasNaMao(jogador, option);

                Console.ResetColor();
                Console.WriteLine("\n" + @"Use ← e → para navegar | ENTER para selecionar e ESC para sair.");

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

                        Console.WriteLine($"\nVocê selecionou o carta {jogador.Mao[option].Nome}.");

                        Console.WriteLine("\nAperte ENTER para confirmar, qualquer outra tecla para voltar.");

                        if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                        {
                            selecionado = true;
                        }
                        break;

                    case ConsoleKey.Escape:
                        selecionado = true;
                        voltar = true;
                        break;
                }
            }
            if (voltar) return -10;
            else return option;
        }

        //embaralha as cartas do jogador
        public static Queue<ICartaUsavel> EmbaralharCartas(List<ICartaUsavel> cartas)
        {
            // Embaralha a lista de cartas e coloca na fila
            var cartasEmbaralhadas = cartas.OrderBy(c => Guid.NewGuid()).ToList();
            return new Queue<ICartaUsavel>(cartasEmbaralhadas);
        }


        //Compra as cartas pra mão do jogador
        public static void ComprarCartas(Personagem jogador)
        {
            while (jogador.Mao.Count < 7 && jogador.BaralhoCompra.Count > 0)
            {
                var cartaComprada = jogador.BaralhoCompra.Dequeue();
                jogador.Mao.Add(cartaComprada);
            }
            if (jogador.BaralhoCompra.Count == 0)
            {
                Console.WriteLine("Baralho vazio. Reciclando descarte...");
                jogador.BaralhoCompra = PersonagemController.EmbaralharCartas(jogador.BaralhoDescarte);
                jogador.BaralhoDescarte.Clear();
            }

        }

        public static void RecarregarBaralho(Personagem jogador)
        {
            if (jogador.BaralhoDescarte.Count > 0)
            {
                Console.WriteLine("Reciclando cartas do baralho...");
                jogador.BaralhoCompra = PersonagemController.EmbaralharCartas(jogador.BaralhoDescarte);
                jogador.BaralhoDescarte.Clear();
            }
            else
            {
                Console.WriteLine("Não há mais cartas para reciclar.");
            }
        }

        public static void AdicionarCartaAoBaralho(Personagem jogador, ICartaUsavel carta)
        {
            jogador.BaralhoCompleto.Add(carta);
            jogador.BaralhoCompra = new Queue<ICartaUsavel>(PersonagemController.EmbaralharCartas(jogador.BaralhoCompleto));
        }

        #endregion

        #region Cuida da condições e da vida do Personagem
        //Restaura os status do jogador a cada rodada
        public static void RestaurarJogador(Personagem jogador)
        {
            jogador.VidaAtual = jogador.VidaAtual + jogador.Regeneracao;
            jogador.ManaAtual = jogador.ManaMax;
            jogador.StaminaAtual = jogador.StaminaMax;
        }

        #endregion
    }
}

