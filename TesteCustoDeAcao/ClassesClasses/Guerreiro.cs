using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCustoDeAcao.ClassesCartas;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesClasses
{
    public class Guerreiro : ClasseRPG
    {
        public override int VidaMax => 150;

        public override int ManaMax => 30;

        public override int StaminaMax => 100;

        public override string NomeClasse => "Guerreiro";

        public override string DescricaoClasse => "Vida alta e mana baixa. Resistente e formidavel";

        public override List<ICartaUsavel> BaralhoClasse { get; }

    }

    /*
     public class Guerreiro : ClasseRPG
{
    public override string NomeClasse => "Guerreiro";
    public override string DescricaoClasse => "Forte, resiste bem a dano, stamina alta.";
    public override int VidaMax => 150;
    public override int ManaMax => 30;
    public override int StaminaMax => 100;

    public override List<ICartaUsavel> GetCartasIniciais()
    {
        return new List<ICartaUsavel>
        {
            new Espadada(), new Espadada(), new Espadada(),
            new Escudo(), new Escudo(), new Escudo(),
            new Atordoar(), new Atordoar(),
            new Amolar(), new Amolar()
        };
    }
}

     */
}
