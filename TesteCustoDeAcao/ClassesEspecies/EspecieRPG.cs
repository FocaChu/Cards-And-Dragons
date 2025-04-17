using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao;

namespace CardsAndDragons
{
    // Classe base para todas as EspeciesRPG !!!
    public abstract class EspecieRPG
    {
        public abstract string NomeEspecie { get; }

        public abstract string DescricaoEspecie { get;  }

    }

    /* 
    
        Foi usado polimorfismo em classes.
        Isso aqui basicamente faz com que os objetos(as classes) que são derivadas(que herdam da classe base)
        sejam tratadas como a classe base(a classe EspecieRPG)

        Isso faz com que a gente crie uma classe base e atraves do construtor coloque dentro dela uma classe derivada
        ex: "EspecieRPG especieExemplo = new Humano();"
        isso aqui está criando uma EspecieRPG, só que com as informações de um Humano
     
        Isso permite que o Personagem use qualquer EspecieRPG sem saber se é Humano, Elfo ou qualquer outra especie
        Deixando mais generico
     */

}
