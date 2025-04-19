using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao.ClassesCartas;
using TesteCustoDeAcao;
using CardsAndDragons.ClassesCondicoes;

namespace CardsAndDragons.ClassesDasCartas
{
    public static class FabricaDeCartas
    {
        public static ICartaUsavel CriarFacaEnvenenada()
        {
            return new CartaGenerica
            {
                Nome = "Faca Envenenada",
                Descricao = "Causa 5 de dano e aplica Veneno (2 por turno por 3 turnos)",
                CustoStamina = 35,
                CustoMana = 10,
                Modelo = GerarModeloBasico("4"),
                EParaInimigo = true,
                EfeitoContraInimigo = (jogador, alvo) =>
                {
                    alvo.SofrerDano(5);
                    alvo.Condicoes.Add(new Veneno(2, 3));
                    Console.WriteLine($"{alvo.Nome} sofre 5 de dano e foi envenenado!");
                }
            };
        }

        public static ICartaUsavel CriarEspadada()
        {
            return new CartaGenerica
            {
                Nome = "Espadada",
                Descricao = "Golpe físico que causa 10 de dano.",
                CustoStamina = 25,
                Modelo = GerarModeloBasico("3"),
                EParaInimigo = true,
                EfeitoContraInimigo = (jogador, alvo) =>
                {
                    alvo.SofrerDano(10);
                    Console.WriteLine($"{alvo.Nome} sofreu 10 de dano!");
                }
            };
        }

        public static ICartaUsavel CriarPocaoDeCura()
        {
            return new CartaGenerica
            {
                Nome = "Poção de Cura",
                Descricao = "Restaura 10 de vida.",
                CustoMana = 15,
                Modelo = GerarModeloBasico("2"),
                EParaInimigo = false,
                EfeitoNoJogador = jogador =>
                {
                    jogador.Curar(10);
                    Console.WriteLine($"{jogador.Nome} recuperou 10 pontos de vida.");
                }
            };
        }

        public static ICartaUsavel CriarGolpePesado()
        {
            return new CartaGenerica
            {
                Nome = "Golpe Pesado",
                Descricao = "Esmaga um inimigo causando 30 de dano.",
                CustoStamina = 40,
                Modelo = GerarModeloBasico("1"),
                EParaInimigo = true,
                EfeitoContraInimigo = (jogador, alvo) =>
                {
                    alvo.SofrerDano(30);
                    Console.WriteLine($"{alvo.Nome} sofreu 30 de dano!");
                }

            };

        }

        private static List<string> GerarModeloBasico(string simboloCentral)
        {
            return new List<string>
        {
            "                     ",
            "                     ",
            "                     ",
            $"        {simboloCentral}         ",
            "                     ",
            "                     ",
            $"        {simboloCentral}         ",
            "                     ",
            "                     ",
            "                     ",
        };
        }
    }


}
