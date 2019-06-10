using Dapper.FluentMap.Dommel.Mapping;
using Domain.Models;

namespace Repository.Mappers
{
    public class ClienteMap : DommelEntityMap<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Clientes");
            Map(x => x.Id).ToColumn("ID").IsKey();
            Map(x => x.NomeCompleto).ToColumn("NomeCompleto");
            Map(x => x.Fone).ToColumn("Fone");
            Map(x => x.Email).ToColumn("Email");
        }
    }
}