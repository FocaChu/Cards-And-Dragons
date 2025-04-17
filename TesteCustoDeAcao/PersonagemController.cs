using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons
{
    public static class PersonagemController
    {
        public static EspecieRPG SelecionarEspecie()
        {
            //mostra todas as especies
            var especiesDisponiveis = EspecieHelper.ObterTodasAsEspeciesDisponiveis();

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
            var classesDisponiveis = ClasseHelper.ObterTodasAsClassesDisponiveis();

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
    

    }
}

