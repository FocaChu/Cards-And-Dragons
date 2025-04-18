using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons.ClassesCondicoes;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesCartas
{
    public class FacaEnvenenada : ICartaUsavel
    {
        public string Nome => "Faca Envenenada";

        public string Descricao => "Causa 5 de dano e aplica Veneno (2 de dano por turno por 3 turnos)";

        public int CustoVida => 0;

        public int CustoMana => 0;

        public int CustoStamina => 2;

        public int CustoOuro => 0;

        public List<string> Modelo => new List<string>()
        {
            // A12345678901234567890123  = 23
            @"        1234         ", //1
            @"                     ", //2
            @"                     ", //3
            @"                     ", //4
            @"                     ", //5
            @"        1234         ", //6
            @"                     ", //7
            @"                     ", //8
            @"                     ", //9
            @"        1234         ", //10
            // preencher 10 linhas no total
        };

        public void Usar(Personagem jogador, OInimigo alvo)
        {
            // Verifica recursos
            if (jogador.StaminaAtual < CustoStamina)
            {
                Console.WriteLine("Stamina insuficiente para usar essa carta!");
                return;
            }

            jogador.StaminaAtual -= CustoStamina;

            alvo.VidaAtual -= 5;
            alvo.Condicoes.Add(new Veneno(2, 3));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{jogador.Nome} lançou {Nome} em {alvo.Nome}!");
            Console.ResetColor();

            Console.WriteLine($"→ {alvo.Nome} sofreu 5 de dano e foi envenenado!");
        }
    }

}
