using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons.ClassesCartas;
using CardsAndDragons.ClassesCondicoes;
using CardsAndDragons.Inimigos;
using NAudio.CoreAudioApi;
using TesteCustoDeAcao;
using TesteCustoDeAcao.ClassesCartas;

namespace CardsAndDragons
{
    public class Personagem
    {
        public string Nome { get; set; }

        public EspecieRPG Especie { get; set; }

        public ClasseRPG Classe { get; set; }

        public List<ICartaUsavel> BaralhoCompleto { get; set; } //Baralho completo do jogador

        public Queue<ICartaUsavel> BaralhoCompra { get; set; } = new Queue<ICartaUsavel>(); // Cartas para comprar

        public List<ICartaUsavel> Mao { get; set; } = new List<ICartaUsavel>(); // Cartas na mão

        public List<ICartaUsavel> BaralhoDescarte { get; set; } = new List<ICartaUsavel>(); // Cartas já usadas


        public List<ICondicaoTemporaria> Condicoes = new List<ICondicaoTemporaria>();

        #region Status do Jogador

        public int Regeneracao { get; set; }

        public int Ouro { get; set; }

        public int VidaMax { get; set; }

        public int ManaMax { get; set; }

        public int StaminaMax { get; set; }

        public double XpAtual { get; set; }
        public double XpTotal { get; set; }

        public int Nivel { get; set; }

        //Status "atuais" usados no codigo
        private int vidaAtual;
        private int manaAtual;
        private int staminaAtual;

        #endregion

        #region Reguladores de Status

        //Codigo generico que impede os status de subir alem dos limites impostos por deus ou descer abaixo de 0
        private int ReguladorDeDeus(int valor, int valorMax)
        {
            if (valor < 0) return 0;
            //Se o valor (o status atual) for menor do que zero, o codigo breca e poem ele como zero, evitando coisas como -15 de vida.

            if (valor > valorMax) return valorMax;
            //Se o valor (o status atual) for maior que o limite maximo estipulado, o codigo breca e limita ele, impedido vc ter vida infinita por exemplo

            // Se estiver no intervalo permitido manda o valor normal
            return valor;
        }

        public int Ouros
        {
            get => Ouro;
            set => Ouro = ReguladorDeDeus(value, 1000);
            //Pega a vida atual, seta ela pelos parametros passados e limita ela pelo minimo e maximo
        }

        public int VidaAtual
        {
            get => vidaAtual;
            set => vidaAtual = ReguladorDeDeus(value, VidaMax);
            //Pega a vida atual, seta ela pelos parametros passados e limita ela pelo minimo e maximo
        }

        public int ManaAtual
        {
            get => manaAtual;
            set => manaAtual = ReguladorDeDeus(value, ManaMax);
        }

        public int StaminaAtual
        {
            get => staminaAtual;
            set => staminaAtual = ReguladorDeDeus(value, StaminaMax);
        }

        #endregion

        public Personagem(string nome, EspecieRPG especie, ClasseRPG classe)
        {
            this.Nome = nome;
            this.Especie = especie;
            this.Classe = classe;

            this.Ouros = (this.Especie.NomeEspecie == "Anão") ? 150 : 100;

            this.Regeneracao = (this.Especie.NomeEspecie == "Vampiro") ? 1 : 0;

            this.Nivel = 1;
            this.XpTotal = 100;

            // Status máximos
            this.VidaMax = Classe.VidaMax + 100000;
            this.ManaMax = Classe.ManaMax;
            this.StaminaMax = Classe.StaminaMax;

            // Define os status atuais no máximo ao criar o Personagem
            this.VidaAtual = classe.VidaMax + 100000;
            this.ManaAtual = classe.ManaMax;
            this.StaminaAtual = classe.StaminaMax;

            this.BaralhoCompleto = new List<ICartaUsavel>
            {
                new FacaEnvenenada(),
                new FacaEnvenenada(),
                new FacaEnvenenada(),
                new FacaEnvenenada(),
                new FacaEnvenenada(),
                new FacaEnvenenada(),
                new FacaEnvenenada(),
                new FacaEnvenenada(),
                new FacaEnvenenada(),
                new FacaEnvenenada()
            };
            this.BaralhoCompra = new Queue<ICartaUsavel>(EmbaralharCartas(this.BaralhoCompleto));
        }

        public Queue<ICartaUsavel> EmbaralharCartas(List<ICartaUsavel> cartas)
        {
            // Embaralha a lista de cartas e coloca na fila
            var cartasEmbaralhadas = cartas.OrderBy(c => Guid.NewGuid()).ToList();
            return new Queue<ICartaUsavel>(cartasEmbaralhadas);
        }

        public void ComprarCartas()
        {
            while (this.Mao.Count < 7 && this.BaralhoCompra.Count > 0)
            {
                var cartaComprada = this.BaralhoCompra.Dequeue();
                this.Mao.Add(cartaComprada);
            }
        }

        public override string ToString()
        {
            return $"\nNome: {this.Nome}; " +
                   $"\nNível: {this.Nivel} - {this.XpAtual}/{this.XpTotal}" +
                   $"\nClasse: {this.Classe.NomeClasse} Espécie: {this.Especie.NomeEspecie}" +
                   $"\nVida: {this.VidaAtual}/{this.VidaMax}" +
                   $"\nMana: {this.ManaAtual}/{this.ManaMax}" +
                   $"\nStamina: {this.StaminaAtual}/{this.StaminaMax}" +
                   $"\nOuro: {this.Ouro}";
        }

        public void Curar(int curaRecebida)
        {
            this.VidaAtual = this.VidaAtual + curaRecebida;
        }

        public void AtualizarCondicoes()
        {
            for (int i = Condicoes.Count - 1; i >= 0; i--)
            {
                var condicao = Condicoes[i];

                // Muda a cor conforme o tipo da condição
                DefinirCorDaCondicao(condicao.Nome);

                Console.WriteLine($"{Nome} sofre os efeitos de {condicao.Nome}!");

                // Aplica o efeito
                condicao.AplicarEfeito(this);
                condicao.Atualizar();

                if (condicao.Expirou())
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{Nome} não está mais afetado por {condicao.Nome}.");
                    Condicoes.RemoveAt(i);
                }

                Console.ResetColor();
            }
        }

        private void DefinirCorDaCondicao(string nomeCondicao)
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
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }

        public void UsarCarta(int indice, OInimigo alvo)
        {
            if (indice >= 0 && indice < Mao.Count)
            {
                var carta = Mao[indice];

                // Aplica efeitos
                carta.Usar(this, alvo);

                // Remove da mão
                Mao.RemoveAt(indice);

                // Adiciona ao descarte
                BaralhoDescarte.Add(carta);
            }
        }

        public void ComprarCartasExtras(int qtdCartas)
        {

        }

        public void ContabilizarXp(OInimigo inimigo)
        {
            //double ganhoXp = (50 + (inimigo.Dificuldade * 2));

            double ganhoXp = (this.Especie.NomeEspecie == "Humano") ? ganhoXp = ((45 + (Nivel * 5)) + (inimigo.Dificuldade * 2.5)) : ganhoXp = ((40 + (Nivel * 5)) + (inimigo.Dificuldade * 2));

            XpAtual += ganhoXp;

            Console.WriteLine($"\nVocê ganhou {ganhoXp} de XP!");

            if (XpAtual >= XpTotal)
            {
                Nivel++;
                XpAtual -= XpTotal;
                XpTotal = XpTotal * (Nivel + 1);
                int pontosXp = 3;
                Console.WriteLine($"\nVocê subiu para o nivél {this.Nivel}");
                Console.ReadKey();
                AtribuirPontosXp(pontosXp);
            }
        }

        protected void AtribuirPontosXp(int pontosXp)
        {
            int option = 1;
            string[] opcoes = { "Vida", "Mana", "Stamina", "Confirmar e sair" };

            while (pontosXp > 0)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"\n========== Melhorar Atributos ==========\n");

                Console.WriteLine($"\nPontos de atributo disponíveis: {pontosXp}");

                Console.WriteLine($"\nVida: {this.VidaMax} \nMana: {this.ManaMax} \nStamina: {this.StaminaMax}");

                Console.WriteLine(@"\n\nUse ↑ e ↓ para navegar, Enter para selecionar:\n");

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
                        if (option == 4) return; // Sai do menu
                        else
                        {
                            Console.WriteLine($"\nQuantos pontos deseja aplicar em {opcoes[option - 1]}?");
                            Console.Write("→ ");

                            if (int.TryParse(Console.ReadLine(), out int quantidade) && quantidade > 0 && quantidade <= pontosXp)
                            {
                                switch (option)
                                {
                                    case 1:
                                        this.VidaMax = VidaMax + (1 * quantidade);
                                        break;
                                    case 2:
                                        this.ManaMax = ManaMax + (1 * quantidade);
                                        break;
                                    case 3:
                                        this.StaminaMax = StaminaMax + (1 * quantidade);
                                        break;
                                }

                                pontosXp -= quantidade;
                            }
                            else
                            {
                                Console.WriteLine("\nValor inválido.");
                                Console.ReadKey();
                            }
                        }
                        break;
                }
            }
        }
    }
}
