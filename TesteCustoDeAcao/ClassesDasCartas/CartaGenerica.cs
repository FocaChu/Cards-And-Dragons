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

        public List<string> Modelo { get; set; }

        // Os dois tipos de efeito possíveis
        public Action<Personagem, OInimigo> EfeitoContraInimigo { get; set; }
        public Action<Personagem> EfeitoNoJogador { get; set; }

        public bool EParaInimigo { get; set; }

        // Método normal da interface
        public void Usar(Personagem jogador, OInimigo alvo)
        {
            if (!TemRecursos(jogador))
            {
                Console.WriteLine("Você não tem recursos suficientes.");
                return;
            }

            ConsumirRecursos(jogador);

            if (EParaInimigo)
            {
                // VERIFICA SE O ALVO EXISTE
                if (alvo == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Erro: Nenhum inimigo foi selecionado para uma carta de ataque.");
                    Console.ResetColor();
                    return;
                }

                EfeitoContraInimigo?.Invoke(jogador, alvo);
            }
            else
            {
                EfeitoNoJogador?.Invoke(jogador);
            }
        }

        public bool UsarComRetorno(Personagem jogador, OInimigo alvo)
        {
            if (!TemRecursos(jogador))
            {
                Console.WriteLine("Você não tem recursos suficientes.");
                return false;
            }

            ConsumirRecursos(jogador);

            if (EParaInimigo)
            {
                if (alvo == null)
                {
                    Console.WriteLine("Erro: Nenhum inimigo foi selecionado.");
                    return false;
                }

                EfeitoContraInimigo?.Invoke(jogador, alvo);
            }
            else
            {
                EfeitoNoJogador?.Invoke(jogador);
            }

            return true;
        }



        private bool TemRecursos(Personagem jogador)
        {
            return jogador.VidaAtual >= CustoVida &&
                   jogador.ManaAtual >= CustoMana &&
                   jogador.StaminaAtual >= CustoStamina &&
                   jogador.Ouros >= CustoOuro;
        }

        private void ConsumirRecursos(Personagem jogador)
        {
            jogador.VidaAtual -= CustoVida;
            jogador.ManaAtual -= CustoMana;
            jogador.StaminaAtual -= CustoStamina;
            jogador.Ouros -= CustoOuro;
        }
    }

}

