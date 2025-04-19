using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons;
using CardsAndDragons.ClassesCondicoes;
using CardsAndDragons.Controllers;
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

        public void RealizarTurno(Personagem jogador, int rodada)
        {
            if (PodeUsarHabilidade(rodada) && !CondicaoController.VerificarSilencio(Condicoes))
            {
                BaseInimigo.UsarHabilidade(jogador);
            }
            else
            {
                if (PodeUsarHabilidade(rodada) && CondicaoController.VerificarSilencio(Condicoes))
                {
                    Console.WriteLine($"{this.Nome} foi silenciado e não pode usar sua habilidade...");
                    BaseInimigo.Atacar(jogador);
                }
                else  BaseInimigo.Atacar(jogador);
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
