using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons.ClassesDasCartas;
using CardsAndDragons.Controllers;
using CardsAndDragons.Inimigos;
using NAudio.Wave;
using TesteCustoDeAcao;
using TesteCustoDeAcao.ClassesCartas;

namespace CardsAndDragons
{
    enum EstadoDoJogo
    {
        MenuInicial,
        Creditos,
        SelecionarDificuldade,
        SelecaoPersonagem,
        CriarPersonagem,
        Jogo,
        Derrota,
        Encerrar
    }

    class Programa
    {
        #region Musica de Fundo

        static WaveOutEvent PlayerDojogo;
        static AudioFileReader AudioDoJogo;
        static void TocarFundo(string nomeDoAudio)
        {
            // se o player tiver sendo usado
            if (PlayerDojogo != null)
            {
                //pausa o player
                PlayerDojogo.Stop();
                //Dispose tira o cd que tava player
                PlayerDojogo.Dispose();
                //so pra garantir que ele nao tem nada
                // e meio como se vc quebrasse a caixa de som pois ele so serve pra um uso é uma player descartavel
                PlayerDojogo = null;
            }
            //se tiver algo no cd
            if (AudioDoJogo != null)
            {
                //limpa o que tem gravado no cd
                AudioDoJogo.Dispose();
                // garatia de que o cd vai ta limpo
                AudioDoJogo = null;
            }
            //AppDomain.CurrentDomain.BaseDirectory retorna onde o jogo esta sendo executado/ Audios e o nome da pasta
            string LocalDoAudio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audios", nomeDoAudio);

            //lee o audio 
            AudioDoJogo = new AudioFileReader(LocalDoAudio);

            //cria um novo player 
            PlayerDojogo = new WaveOutEvent();

            //init poem o audio no reprodutor (poem cd na caixa de som)
            PlayerDojogo.Init(AudioDoJogo);
            PlayerDojogo.Play();
        }
        #endregion

        #region Variaveis Static
        //Abre o menu assim que começa o jogo
        static EstadoDoJogo estadoAtual = EstadoDoJogo.MenuInicial;

        //Guarda nosso jogador
        static List<Personagem> oJogador = new List<Personagem>();

        //Guarda os inimigos de cada batalha
        static List<OInimigo> inimigosDaFase = new List<OInimigo> { };

        //forma mais intuitva de chamar o jogador que estamos usando
        static int jogadorAtual = 0;

        //define a dificuldade das lutas
        static int dificuldadeAtual = 3;
        #endregion

        static void Main(string[] args)
        {
            while (estadoAtual != EstadoDoJogo.Encerrar)
            {
                switch (estadoAtual)
                {
                    case EstadoDoJogo.MenuInicial:
                        MostrarMenuInicial();
                        break;

                    case EstadoDoJogo.Creditos:
                        Creditos();
                        break;

                    case EstadoDoJogo.SelecionarDificuldade:
                        MudarDificuldade();
                        break;

                    case EstadoDoJogo.CriarPersonagem:
                        CriarPersonagem();
                        break;

                    case EstadoDoJogo.Jogo:
                        JogarPartida();
                        break;

                    case EstadoDoJogo.Derrota:
                        MostrarDerrota();
                        break;
                }

                Console.Clear();
            }
        }

        #region Menus

        static void Titulo()
        {
            //mostra o titulo do jogo// degrade: magenta -> red -> dark red -> dark yellow -> yellow
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"              (   (     (            (     (                      )     ) (     ");
            Console.WriteLine(@"   (    (     )\ ))\ )  )\ )         )\ )  )\ )   (     (      ( /(  ( /( )\ )  ");
            Console.WriteLine(@"   )\   )\   (()/(()/( (()/(   (    (()/( (()/(   )\    )\ )   )\()) )\()|()/(  ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@" (((_|(((_)(  /(_))(_)) /(_))  )\    /(_)) /(_)|(((_)( (()/(  ((_)\ ((_)\ /(_)) ");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@" )\___)\ _ )\(_))(_))_ (_))   ((_)  (_))_ (_))  )\ _ )\ /(_))_  ((_) _((_|_))   ");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"((/ __(_)_\(_) _ \|   \/ __|  | __|  |   \| _ \ (_)_\(_|_)) __|/ _ \| \| / __|  ");
            Console.WriteLine(@" | (__ / _ \ |   /| |) \__ \  | _|   | |) |   /  / _ \   | (_ | (_) | .` \__ \  ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"  \___/_/ \_\|_|_\|___/|___/  |___|  |___/|_|_\ /_/ \_\   \___|\___/|_|\_|___/  ");

            Console.ResetColor();
            Console.WriteLine("\n\n");
        }

        static void MostrarMenuInicial()
        {
            //TocarFundo("fundo de criacao de personagem.mp3");
            oJogador.Clear();
            Titulo();

            string[] opcoes = new string[]
            {
                "Jogar",
                "Credítos",
                "Dificuldade",
                "Sair"
            };

            int escolha = MostrarMenuSelecao(true, "Menu Inicial", opcoes);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            switch (escolha)
            {
                case 1:
                    estadoAtual = EstadoDoJogo.CriarPersonagem;
                    break;
                case 2:
                    estadoAtual = EstadoDoJogo.Creditos;
                    break;
                case 3:
                    estadoAtual = EstadoDoJogo.SelecionarDificuldade;
                    break;
                case 4:
                    estadoAtual = EstadoDoJogo.Encerrar;
                    break;
            }
        }

        static void MudarDificuldade()
        {
            string[] dificuldadesEscolhidas = new string[]
            {
                "Facil",
                "Médio",
                "Dificil",
                "Sair"
            };

            int escolha = MostrarMenuSelecao(false, "DIFICULDADE", dificuldadesEscolhidas);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            switch (escolha)
            {
                case 1:
                    dificuldadeAtual = 1;
                    break;
                case 2:
                    dificuldadeAtual = 3;
                    break;
                case 3:
                    dificuldadeAtual = 6;
                    break;
                case 4:
                    Console.WriteLine("\n\n\nVoltando...");
                    Console.ReadKey();
                    break;
            }
            estadoAtual = EstadoDoJogo.MenuInicial;
        }

        static int MostrarMenuSelecao(bool mostrarTitulo, string titulo, string[] opcoes)
        {
            int option = 1;
            bool selecionado = false;

            Console.CursorVisible = false;

            while (!selecionado)
            {
                Console.Clear();

                if (mostrarTitulo) Titulo();

                if (!string.IsNullOrEmpty(titulo))
                {
                    Console.WriteLine($"\n==========  {titulo.ToUpper()}  ==========\n");
                }

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n====================================\n");
                for (int i = 0; i < opcoes.Length; i++)
                {
                    Console.ForegroundColor = (i + 1 == option) ? ConsoleColor.DarkGray : ConsoleColor.White;
                    Console.WriteLine($"{(i + 1 == option ? ">>" : "  ")} {opcoes[i]}");
                }
                Console.ResetColor();
                Console.WriteLine("\n====================================\n");

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (option > 1) option--;
                        break;

                    case ConsoleKey.DownArrow:
                        if (option < opcoes.Length) option++;
                        break;

                    case ConsoleKey.Enter:
                        selecionado = true;
                        break;
                }
            }

            return option;
        }

        static void Creditos()
        {
            Console.WriteLine("\n--- Créditos da Jornada ---\n");

            Console.WriteLine("\nArquiteto e Invocador de Monstros: João Augusto Cordeiro\n");

            Console.WriteLine("\nArtesão de Cartas e Guardião das Relíquias: Yago Von Krüger Fukuoka\n");

            Console.WriteLine("\nGenerais: Isaque Anacleto de Meira & Kauã Gabriel dos Santos\n");

            Console.WriteLine("\nIlusionista e Barda Oficial: Emylli Sousa Lima\n");

            Console.WriteLine("\nObrigado por jogar nossa aventura! \n\n\nPressione qualquer tecla para retornar...");

            Console.ReadKey();
            estadoAtual = EstadoDoJogo.MenuInicial;
        }

        #endregion

        static void CriarPersonagem()
        {
            bool acabar = false;
            bool resetar = false;
            while (!acabar)
            {

                EspecieRPG especieEscolhida = PersonagemController.SelecionarEspecie();

                //parte do codigo que permite voltar ao menu inicial e cancelar jogar
                if (especieEscolhida == null)
                {
                    estadoAtual = EstadoDoJogo.MenuInicial;
                    break;

                }

                ClasseRPG classeEscolhida = PersonagemController.EscolherClasse();

                //parte do codigo que permite voltar e escolher outra especie
                if (classeEscolhida == null)
                {
                    resetar = true;
                    break;

                }

                string[] opcoesConfirmacao = { "Sim", "Não" };
                int option = MostrarMenuSelecao(false, "Confirmação de Personagem", opcoesConfirmacao);

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.White;
                if (option == 1)
                {
                    //Cria o persongaem do jogador
                    var jogador = PersonagemController.CriarPersonagem(especieEscolhida, classeEscolhida);
                    oJogador.Add(jogador);

                    PersonagemController.ExibirJogador(jogador, true);

                    estadoAtual = EstadoDoJogo.Jogo;
                    acabar = true;
                    Console.WriteLine("\n\n Aperte qualquer tecla para continuar");
                    Console.ReadKey();
                }
                else
                {
                    estadoAtual = EstadoDoJogo.MenuInicial;
                    acabar = true;
                }
            }
            if (resetar) CriarPersonagem();

        }

        #region Combate

        static void JogarPartida()
        {
            //TocarFundo("trilha cortada inuyacha.mp3");

            Console.WriteLine("=== Jogo Iniciado ===");
            Console.WriteLine("Escolhendo cartas, iniciando batalha...\n\n");

            bool acabarJogo = false;
            bool acabarBatalha = false;
            bool primeiroTurno = true;

            //começa o jogo
            while (!acabarJogo)
            {
                //define os inimigos da batalha com base na dificuldade atual
                GerarOsInimigos(dificuldadeAtual);

                //faz a classe batalha recebendo os inimigos e o jogador
                Batalha batalha = new Batalha(oJogador[jogadorAtual], inimigosDaFase);

                //permite que outra batalha começe
                acabarBatalha = false;
                primeiroTurno = true;

                //começa uma batalha
                while (!acabarBatalha)
                {
                    Console.CursorVisible = false;

                    if (primeiroTurno)
                    {
                        batalha.jogador.Condicoes.Clear();
                        BatalhaController.NovaRodada(batalha);
                        primeiroTurno = false;
                    }

                    //Mostra os inimigos ao mesmo tempo que deixa escolher uma ação
                    int acao = BatalhaController.MenuBatalha(batalha);

                    //verifica e efetua a ação
                    switch (acao)
                    {
                        case 1:
                            BatalhaController.AcaoUsarCarta(batalha);
                            break;

                        case 2:
                            BatalhaController.AcaoExibir(batalha);
                            break;

                        case 3:
                            BatalhaController.AcaoPassarTurno(batalha);

                            Console.ReadKey();

                            int resultadoRodada = BatalhaController.VerificarResultadoRodada(batalha);

                            switch (resultadoRodada)
                            {
                                case 1:
                                    estadoAtual = EstadoDoJogo.Derrota;
                                    break;

                                case 2:
                                    acabarBatalha = true;
                                    break;

                                case 3:
                                    BatalhaController.NovaRodada(batalha);
                                    break;
                            }

                            break;
                    }
                    Console.ReadKey();



                }

            }
        }
        

        static void GerarOsInimigos(int dificuldade)
        {
            inimigosDaFase.Clear();
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
        }

        static void MostrarDerrota()
        {
            Console.WriteLine("Você perdeu!");
            Console.WriteLine("1 - Voltar ao menu");
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                estadoAtual = EstadoDoJogo.MenuInicial;
            }
        }

        #endregion
    }
}