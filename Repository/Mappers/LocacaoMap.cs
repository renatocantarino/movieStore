using Dapper.FluentMap.Dommel.Mapping;
using Domain.Models;

namespace Repository.Mappers
{
    public class LocacaoMap : DommelEntityMap<Locacao>
    {
        public LocacaoMap()
        {
            ToTable("Locacaos");
            Map(x => x.Id).ToColumn("ID").IsKey();
            Map(x => x.DataDevolucao).ToColumn("DataDevolucao");
            Map(x => x.DataLocacao).ToColumn("DataLocacao");
            Map(x => x.idCliente).ToColumn("idCliente");
            Map(x => x.idFilme).ToColumn("idFilme");

            //Ignorados
            Map(x => x.Cliente).Ignore();
            Map(x => x.Filme).Ignore();
        }
    }
}