using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao.ClassesCartas;
using TesteCustoDeAcao;
using CardsAndDragons.ClassesDasCartas;

namespace CardsAndDragons.ClassesClasses
{
    public class Guerreiro : ClasseRPG
    {
        public override int VidaMax => 150;

        public override int ManaMax => 30;

        public override int StaminaMax => 100;

        public override string NomeClasse => "Guerreiro";

        public override string DescricaoClasse => "Vida alta e mana baixa. Resistente e formidavel";

        public override List<ICartaUsavel> GetCartasIniciais()
        {
            return new List<ICartaUsavel>
    {
        FabricaDeCartas.CriarEspadada(), FabricaDeCartas.CriarEspadada(), FabricaDeCartas.CriarEspadada(), FabricaDeCartas.CriarEspadada(),
        FabricaDeCartas.CriarPocaoDeCura(), FabricaDeCartas.CriarPocaoDeCura(),FabricaDeCartas.CriarPocaoDeCura(),
        FabricaDeCartas.CriarGolpePesado(), FabricaDeCartas.CriarGolpePesado()
    };
        } 

    }
}
