using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons.Inimigos;
using NAudio.Wave;

namespace CardsAndDragons
{
    public class Morcego : InimigoRPG
    {
        public override int VidaMax => 50;
        public int VidaAtual { get; set; } 
        public override int DanoBase => 10;
        public override int Dificuldade => 4;
        public override string Nome => "Morcego";
        public override List<string> Modelo => new List<string>()
        {
            
            @"                         ", //1 
            @"      /\         /\      ", //2
            @"     /  \ (\_/) /  \     ", //3
            @"    / .''.(o.o).''. \    ", //4
            @"   /.' _/ / * \ \_ '.\   ", //5
            @"  /` .' `\\___//´ '. ´\  ", //6
            @"  \.-'   \(-V-)/   '-./  ", //7
            @"   \      ¨   ¨      /   ", //8
            @"                         ", //9
            @"                         ", //10

        // preencher 10 linhas no total
        };
        public Morcego()
        {
            this.VidaAtual = this.VidaMax;
        }
        public override int CooldownHabilidade => 4; // a cada 4 rodadas usa habilidade

        public override void Atacar(Personagem jogador)
        {
            //string LocalDoAudio = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Audios", "atack morcego.mp3");
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
            Console.WriteLine($"{this.Nome} drenou {this.DanoBase} de vida de {jogador.Nome}!"); 
            jogador.VidaAtual = jogador.VidaAtual - this.DanoBase;
            this.VidaAtual = this.VidaAtual + this.DanoBase;
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