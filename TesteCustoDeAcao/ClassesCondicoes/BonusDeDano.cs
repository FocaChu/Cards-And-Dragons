﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesCondicoes
{
    public class BonusDeDano : ICondicaoTemporaria
    {
        public string Nome => "Bônus de Dano";

        public int Nivel { get; set; }

        public int Duracao { get; set; }

        public BonusDeDano(int nivel, int duracao)
        {
            Nivel = nivel;
            Duracao = duracao;
        }

        public override string ToString()
        {
            return $"{this.Nome} Nível: {this.Nivel} / Duração: {this.Duracao}";
        }

        public void AplicarEfeito(Personagem jogador)
        {
            jogador.BonusDeDano += Nivel;
            Console.WriteLine($"{jogador.Nome} recebe +{Nivel} de dano!");
        }

        public void AplicarEfeito(OInimigo inimigo) { } // Não se aplica a inimigo

        public void Atualizar()
        {
            Duracao--;
        }

        public bool Expirou() => Duracao <= 0;
    }

}
