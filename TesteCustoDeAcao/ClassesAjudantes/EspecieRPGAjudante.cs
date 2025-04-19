using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CardsAndDragons
{
    public static class EspecieRPGAjudante
    {
    /*
    
    Codigo a base de Reflection(função extracorporea do codigo que o faz ver a si mesmo)

    Oque ele ta fazendo?
    - Procurando todas as classes concretas que herdam de EspecieRPG

    - Criando instâncias automaticamente de cada uma

    - Retornando uma lista com todas essas classes

    Oque significa "public static class"
    É uma classe auxiliar estática. Isso significa que
    Você não precisa criar um objeto dela pra usar dentro do codigo
    Ex "EspecieHelper.ObterTodasAsEspeciesDisponiveis();" já funciona direto
    */
        public static List<EspecieRPG> ObterTodasAsEspeciesDisponiveis()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(EspecieRPG)))
                /*
                Isso aqui é nosso filtro:
                
                GetType Isso pega todas as classes, structs, interfaces, etc. do nosso projeto.
                
                Where(t => metodo que começa o filtro com suas exigencias. t é a variavel que representa o dado que estamos procurando e a expresão lambida que ta fazned o filtro

                t.IsClass signifca que t(nosso dado) tem que ser uma classe, qualquer outra coisa é ignorada 200%

                !t.IsAbstract signica o nosso dado tem que obrigatoriamente não ser abstrato, ou seja, que de pra instaciar ele

                t.IsSubclassOf(typeof(EspecieRPG)) signifca que tem que ser uma subclasse da nossa classe base EspecieRPG, outras subclasses vão ser ignoradas
                */

                .Select(t => (EspecieRPG)Activator.CreateInstance(t))
                .ToList();

            /*
               Activator.CreateInstance(t) cria uma instância da classe usando o construtor padrão (sem parâmetros).

                Tamo usando ClasseRPG porque todas as Especies(Humano etc) são EspecieRPG só que polimorfadas

                Isso te nos dá uma lista de instâncias prontas das classes disponíveis.
                Ai com essa lista da pra usar o For e mostrar ela na tela listada automaticamente
                Assim evitando ter que mudar 15 partes diferentes do codigo sempre que adicionar uma Especie nova.
             */
        }
    }
}