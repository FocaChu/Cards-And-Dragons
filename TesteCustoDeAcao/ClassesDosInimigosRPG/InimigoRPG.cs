using System.Collections.Generic;

namespace CardsAndDragons.Inimigos
{
    public abstract class InimigoRPG
    {
        public abstract int VidaMax { get; }
        public abstract int DanoBase { get; }
        public abstract string Nome { get; }
        public abstract int Dificuldade { get; }
        public abstract List<string> Modelo { get; }

        public abstract int CooldownHabilidade { get; }

        //Mecanicas para combate

        public abstract void Atacar(Personagem jogador);

        public abstract void UsarHabilidade(Personagem jogador);

        public abstract bool PodeUsarHabilidade(int rodadaAtual);

        public abstract void RealizarTurno(Personagem jogador, int rodadaAtual);

    }
}
