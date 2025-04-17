using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons.Inimigos;
using NAudio.Wave;

namespace CardsAndDragons
{
    public class Esqueleto : InimigoRPG
    {
        public override int VidaMax => 30;
        public int VidaAtual { get; set; }
        public override int DanoBase => 10;
        public override int Dificuldade => 1;
        public override string Nome => "Esqueleto";
        public override List<string> Modelo => new List<string>()
        {
            //12345678901234567890123  = 23
            @"          ___          ", //1 
            @"         (o.o)         ", //2
            @"         _|=|_         ", //3
            @"       / .=|=. \       ", //4
            @"       \ .=|=. /       ", //5
            @"       (:(_=_):)       ", //6
            @"         || ||         ", //7
            @"         () ()         ", //8
            @"         || ||         ", //9
            @"        ==' '==        ", //10
             // preencher 10 linhas no total
        }; 

        public override int CooldownHabilidade => 3; // a cada 3 rodadas usa habilidade

        public override void Atacar(Personagem jogador)
        {
            //string LocalDoAudio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audios", "atack esqueletoAudio.mp3");
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
            Console.WriteLine($"{this.Nome} atacou {jogador.Nome} causando {this.DanoBase} de dano critico!");
            jogador.VidaAtual = jogador.VidaAtual - (this.DanoBase * 2);
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
