using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons.ClassesDasCartas;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesClasses
{
    public class Arqueiro : ClasseRPG
    {
        public override int VidaMax => 100;

        public override int ManaMax => 50;

        public override int StaminaMax => 80;

        public override string NomeClasse => "Arqueiro";

        public override string DescricaoClasse => "Stamina alta e mana baixa. Ataques versateis e dano abundante.";

        public override List<ICartaUsavel> GetCartasIniciais()
        {
            return new List<ICartaUsavel>
    {
        FabricaDeCartas.CriarEspadada(), FabricaDeCartas.CriarEspadada(), FabricaDeCartas.CriarEspadada(),
        FabricaDeCartas.CriarFlechaEnvenenada(), FabricaDeCartas.CriarFlechaEnvenenada(),
        FabricaDeCartas.CriarFlechaAfiada(), FabricaDeCartas.CriarFlechaAfiada(),
    };
        }
    }
}