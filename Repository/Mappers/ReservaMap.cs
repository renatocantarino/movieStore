using Dapper.FluentMap.Dommel.Mapping;
using Domain.Models;

namespace Repository.Mappers
{
    public class ReservaMap : DommelEntityMap<Reserva>
    {
        public ReservaMap()
        {
            ToTable("Reservas");
            Map(x => x.Id).ToColumn("ID").IsKey();
            Map(x => x.DataReserva).ToColumn("DataReserva");
            Map(x => x.idCliente).ToColumn("idCliente");
            Map(x => x.idFilme).ToColumn("idFilme");

            //Ignorados
            Map(x => x.Cliente).Ignore();
            Map(x => x.Filme).Ignore();
        }
    }
}