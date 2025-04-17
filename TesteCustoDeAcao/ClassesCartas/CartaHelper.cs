using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TesteCustoDeAcao.ClassesCartas
{
    public static class CartaHelper
    {
        public static List<ICartaUsavel> ObterCartasEspecificas()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ICartaUsavel).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(t => (ICartaUsavel)Activator.CreateInstance(t))
                .ToList();
        }

        public static List<ICartaUsavel> ObterCartasGenericas()
        {
            return new List<ICartaUsavel>
        {
            new CartaGenerica
            {
                Nome = "Faca",
                Descricao = "Causa 5 de dano a um inimigo.",
                CustoVida = 0,
                CustoMana = 0,
                CustoStamina = 2,
                CustoOuro = 0,
                Efeito = (j, inimigos) =>
                {
                    if (inimigos.Count > 0) inimigos[0].SofrerDano(5);
                }
            },
            new CartaGenerica
            {
                Nome = "Poção de Cura",
                Descricao = "Cura 10 de vida.",
                CustoVida = 0,
                CustoMana = 3,
                CustoStamina = 0,
                CustoOuro = 0,
                Efeito = (j, _) => j.Curar(10)
            }
        };
        }

        public static List<ICartaUsavel> ObterTodasCartasDisponiveis()
        {
            return ObterCartasEspecificas().Concat(ObterCartasGenericas()).ToList();
        }
    }
}
