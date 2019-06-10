using Dapper.FluentMap.Dommel.Mapping;
using Domain.Models;

namespace Repository.Mappers
{
    public class FilmeMap : DommelEntityMap<Filme>
    {
        public FilmeMap()
        {
            ToTable("filmes");
            Map(x => x.Id).ToColumn("ID").IsKey();
            Map(x => x.AnoLancamento).ToColumn("AnoLancamento");
            Map(x => x.Resumo).ToColumn("Resumo");
            Map(x => x.Caminho).ToColumn("Caminho");
            Map(x => x.Nome).ToColumn("Nome");
            Map(x => x.Alugado).ToColumn("Alugado");
        }
    }
}