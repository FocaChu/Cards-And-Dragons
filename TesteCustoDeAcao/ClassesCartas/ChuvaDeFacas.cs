using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons;

namespace TesteCustoDeAcao.ClassesCartas
{
    public class ChuvaDeFacas : ICartaUsavel
    {
        public string Nome => "Chuva de Facas";

        public string Descricao => "Causa 8 de dano a todos os inimigos.";

        public int CustoVida => 0;

        public int CustoMana => 2;

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

        public void Usar(Personagem jogador, List<OInimigo> inimigos)
        {
            if (jogador.ManaAtual < CustoMana || jogador.StaminaAtual < CustoStamina)
            {
                Console.WriteLine("Recursos insuficientes para usar Chuva de Facas.");
                return;
            }

            jogador.ManaAtual -= CustoMana;
            jogador.StaminaAtual -= CustoStamina;

            foreach (var inimigo in inimigos)
            {
                inimigo.SofrerDano(8);
                Console.WriteLine($"{inimigo.Nome} recebeu 8 de dano!");
            }
        }
    }
}
