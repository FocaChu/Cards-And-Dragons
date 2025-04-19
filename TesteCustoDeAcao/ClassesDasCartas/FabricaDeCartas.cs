using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao.ClassesCartas;
using TesteCustoDeAcao;
using CardsAndDragons.ClassesCondicoes;
using CardsAndDragons.Controllers;

namespace CardsAndDragons.ClassesDasCartas
{
    public static class FabricaDeCartas
    {

        public static ICartaUsavel CriarFeiticoDeGelo()
        {
            return new CartaGenerica
            {
                Nome = "Feitiço de Gelo",
                Descricao = "Um feitiço gélido que pode congelar um inimigo o impedindo de atacar.",
                CustoMana = 50,
                Modelo = GerarModeloBasico("8"),
                EParaInimigo = true,
                EfeitoContraInimigo = (jogador, alvo) =>
                {
                    CondicaoController.AplicarOuAtualizarCondicao(new Congelamento(), alvo.Condicoes);
                    Console.WriteLine($"{alvo.Nome} foi congelado!");
                }
            };
        }
        public static ICartaUsavel CriarFlechaAfiada()
        {
            return new CartaGenerica
            {
                Nome = "Flecha Afiada",
                Descricao = "Uma flecha de ponta afiada que pode Cortas inimigos.",
                CustoStamina = 35,
                CustoMana = 10,
                Modelo = GerarModeloBasico("7"),
                EParaInimigo = true,
                EfeitoContraInimigo = (jogador, alvo) =>
                {
                    alvo.SofrerDano(10);
                    CondicaoController.AplicarOuAtualizarCondicao(new Sangramento(29, 2), alvo.Condicoes);
                    Console.WriteLine($"{alvo.Nome} sofre 5 de dano e foi cortado!");
                }
            };
        }

        public static ICartaUsavel CriarPraga()
        {
            return new CartaGenerica
            {
                Nome = "Praga",
                Descricao = "Lança uma praga que Amaldiçoa e Envenena o inimigo o inimigo.",
                CustoMana = 40,
                Modelo = GerarModeloBasico("6"),
                EParaInimigo = true,
                EfeitoContraInimigo = (jogador, alvo) =>
                {
                    CondicaoController.AplicarOuAtualizarCondicao(new Veneno(2, 4), alvo.Condicoes);
                    CondicaoController.AplicarOuAtualizarCondicao(new Maldicao(5), alvo.Condicoes);
                    Console.WriteLine($"{alvo.Nome} foi amaldiçoado e envenenado!");
                }
            };
        }

        public static ICartaUsavel CriarMaldicaoAmarga()
        {
            return new CartaGenerica
            {
                Nome = "Maldição Amarga",
                Descricao = "Causa 5 de dano e aplica 3 de Maldição ao inimigo.",
                CustoMana = 10,
                Modelo = GerarModeloBasico("5"),
                EParaInimigo = true,
                EfeitoContraInimigo = (jogador, alvo) =>
                {
                    alvo.SofrerDano(5);
                    CondicaoController.AplicarOuAtualizarCondicao(new Maldicao(300), alvo.Condicoes);
                    Console.WriteLine($"{alvo.Nome} sofre 5 de dano e foi amaldiçoado!");
                }
            };
        }

        public static ICartaUsavel CriarFlechaEnvenenada()
        {
            return new CartaGenerica
            {
                Nome = "Fleca Envenenada",
                Descricao = "Causa 5 de dano e aplica 3 de Veneno por 3 turnos",
                CustoStamina = 35,
                CustoMana = 10,
                Modelo = GerarModeloBasico("4"),
                EParaInimigo = true,
                EfeitoContraInimigo = (jogador, alvo) =>
                {
                    alvo.SofrerDano(5);
                    CondicaoController.AplicarOuAtualizarCondicao(new Veneno(3, 3), alvo.Condicoes);
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
