using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons;

namespace TesteCustoDeAcao.ClassesCartas
{
    public class CartaGenerica : ICartaUsavel
        {
            public string Nome { get; set; }

            public string Descricao { get; set; }

            public int CustoVida { get; set; }

            public int CustoMana { get; set; }

            public int CustoStamina { get; set; }

            public int CustoOuro { get; set; }

            public List<string> Modelo => new List<string>()
            {
            //123456789012345678901  = 21
            @"        1234        ", //1
            @"                    ", //2
            @"                    ", //3
            @"                    ", //4
            @"                    ", //5
            @"        1234        ", //6
            @"                    ", //7
            @"                    ", //8
            @"                    ", //9
            @"        1234        ", //10
            // preencher 10 linhas no total
            };

            public Action<Personagem, List<OInimigo>> Efeito { get; set; }

            public void Usar(Personagem jogador, OInimigo alvo)
            {
                // (verificação de custo)
                if (jogador.ManaAtual < CustoMana || jogador.StaminaAtual < CustoStamina || jogador.VidaAtual < CustoVida)
                {
                    Console.WriteLine("Você não tem recursos suficientes.");
                    return;
                }

                jogador.ManaAtual -= CustoMana;
                jogador.StaminaAtual -= CustoStamina;
                jogador.VidaAtual -= CustoVida;
                jogador.Ouros -= CustoOuro;
            }
        }

    }

