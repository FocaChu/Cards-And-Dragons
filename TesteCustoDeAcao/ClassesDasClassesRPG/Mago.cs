using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsAndDragons.ClassesDasCartas;
using TesteCustoDeAcao;

namespace CardsAndDragons.ClassesClasses
{
    public class Mago : ClasseRPG
    {
        public override int VidaMax => 70;

        public override int ManaMax => 150;

        public override int StaminaMax => 50;

        public override string NomeClasse => "Mago";

        public override string DescricaoClasse => "Mana alta e stamina baixa. Feiços poderoso e controle de grupo.";

        public override List<ICartaUsavel> GetCartasIniciais()
        {
            return new List<ICartaUsavel>
    {
        FabricaDeCartas.CriarMaldicaoAmarga(), FabricaDeCartas.CriarMaldicaoAmarga(), FabricaDeCartas.CriarMaldicaoAmarga(),
        FabricaDeCartas.CriarMaldicaoAmarga(), FabricaDeCartas.CriarMaldicaoAmarga(), FabricaDeCartas.CriarMaldicaoAmarga(),
        FabricaDeCartas.CriarPraga(),
        FabricaDeCartas.CriarFeiticoDeGelo()
    };
        }
    }
}
