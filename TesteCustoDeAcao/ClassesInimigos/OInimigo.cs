using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons;
using CardsAndDragons.ClassesCondicoes;
using CardsAndDragons.Inimigos;

namespace TesteCustoDeAcao
{
    public class OInimigo
    {
        //ele pede um inimigo de base pra existir
        public InimigoRPG BaseInimigo { get; private set; }

        public string Nome => BaseInimigo.Nome;

        public int VidaMax => BaseInimigo.VidaMax;

        public int VidaAtual { get; set; }

        public int DanoBase => BaseInimigo.DanoBase;

        public int Dificuldade => BaseInimigo.Dificuldade;

        public List<ICondicaoTemporaria> Condicoes = new List<ICondicaoTemporaria>();

        public List<string> Modelo => BaseInimigo.Modelo;

        //aqui ele recebe esse inimigo pelo construtor
        public OInimigo(InimigoRPG inimigoBase)
        {
            BaseInimigo = inimigoBase;
            VidaAtual = BaseInimigo.VidaMax;
        }

        public void Atacar(Personagem jogador)
        {
            BaseInimigo.Atacar(jogador);
        }

        public bool PodeUsarHabilidade(int rodada)
        {
            return BaseInimigo.PodeUsarHabilidade(rodada);
        }

        public void UsarHabilidade(Personagem jogador)
        {
            BaseInimigo.UsarHabilidade(jogador);
        }

        public void AtualizarCondicoes()
        {
            if(Condicoes.Count > 0)
            for (int i = Condicoes.Count - 1; i >= 0; i--)
            {
                var condicao = Condicoes[i];

                DefinirCorDaCondicao(condicao.Nome);

                Console.WriteLine($"{Nome} sofre os efeitos de {condicao.Nome}!");

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

        public void RealizarTurno(Personagem jogador, int rodada)
        {
            if (PodeUsarHabilidade(rodada))
            {
                BaseInimigo.UsarHabilidade(jogador);
            }
            else
            {
                BaseInimigo.Atacar(jogador);
            }

        }

        public void SofrerDano(int danoSofrido)
        {
            this.VidaAtual = this.VidaAtual - danoSofrido;
        }

        public override string ToString()
        {
            return $"{this.Nome} - PS:{this.VidaAtual}/{this.VidaMax}";
        }
    }

}
