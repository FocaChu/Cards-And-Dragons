using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons.ClassesCondicoes;

namespace CardsAndDragons.Controllers
{
    public static class CondicaoController
    {
        public static void AplicarOuAtualizarCondicao(ICondicaoTemporaria nova, List<ICondicaoTemporaria> condicoes)
        {
            var existente = condicoes.FirstOrDefault(c => c.GetType() == nova.GetType());

            if (existente == null)
            {
                condicoes.Add(nova);
            }
            else if (existente is ICondicaoEmpilhavel empilhavel)
            {
                empilhavel.Fundir(nova);
            }
        }
    }

}
