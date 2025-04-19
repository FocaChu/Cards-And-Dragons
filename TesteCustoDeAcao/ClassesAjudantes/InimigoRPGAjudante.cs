using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons.Inimigos;

namespace CardsAndDragons
{
    public static class InimigoRPGAjudante
    {

     /*
    
    Codigo a base de Reflection só que ele devolve uma lista com os tipos para poder dentro do gerador de inimigos
        criar varios clones deles pro combate sem dar erro.
    */
        public static List<Type> ObterTiposDeInimigosDisponiveis()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(InimigoRPG)))
                .ToList();
        }
    }
}
