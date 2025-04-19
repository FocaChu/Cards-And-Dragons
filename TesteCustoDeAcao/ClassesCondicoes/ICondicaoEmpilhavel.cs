using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDragons.ClassesCondicoes
{
    public interface ICondicaoEmpilhavel : ICondicaoTemporaria
    {
        void Fundir(ICondicaoTemporaria nova);
    }

}
