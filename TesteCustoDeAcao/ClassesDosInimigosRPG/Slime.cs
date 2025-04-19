using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons.ClassesCondicoes;
using CardsAndDragons.Controllers;
using CardsAndDragons.Inimigos;
using NAudio.Wave;

namespace CardsAndDragons
{
    public class Slime : InimigoRPG
    {
        public override int VidaMax => 50;
        public int VidaAtual { get; set; }
        public override int DanoBase => 5;
        public override int Dificuldade => 1;
        public override string Nome => "Slime";
        public override List<string> Modelo => new List<string>()
        {
            //1234567890123456789012345 = 25
            @"                         ", //1
            @"                         ", //2
            @"        XXXXXXXXX        ", //3
            @"      XXX       XXX      ", //4
            @"     XX           XX     ", //5
            @"     X  __     __  X     ", //6
            @"     X    ■   ■    X     ", //7
            @"     XX           XX     ", //8
            @"       XXXXXXXXXXX       ", //9
            @"                         ", //10
            // preencher 10 linhas no total
};

        public override int CooldownHabilidade => 4; // a cada 4 rodadas usa habilidade

        public override void Atacar(Personagem jogador)
        {
            //string LocalDoAudio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audios", "slime Ataque.mp3");
            ////lee o audio
            //var somAtackEsqueleto = new AudioFileReader(LocalDoAudio);
            //// cria o reprodutor de audio
            //var tocadordeaudio = new WaveOutEvent();
            ////poem o audio no reprodutor (poem cd na caixa de som)
            //tocadordeaudio.Init(somAtackEsqueleto);
            //tocadordeaudio.Play();

            Console.WriteLine($"{this.Nome} atacou {jogador.Nome} causando {this.DanoBase} de dano!");
            jogador.VidaAtual = jogador.VidaAtual - this.DanoBase;
        }
        public override bool PodeUsarHabilidade(int rodadaAtual)
        {
            return rodadaAtual % CooldownHabilidade == 0;
        }
       public override void UsarHabilidade(Personagem jogador)
        {
            Console.WriteLine($"{this.Nome} atacou {jogador.Nome} causando {this.DanoBase} de dano ácido!");
            jogador.VidaAtual = jogador.VidaAtual - (this.DanoBase * 2);
            CondicaoController.AplicarOuAtualizarCondicao(new Veneno(1, 2), jogador.Condicoes);
        }

        public override void RealizarTurno(Personagem jogador, int rodadaAtual)
        {
            if (PodeUsarHabilidade(rodadaAtual))
            {
                UsarHabilidade(jogador);
            }
            else
            {
                Atacar(jogador);
            }
        }
    }
}
