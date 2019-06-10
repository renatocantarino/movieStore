using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Repository.Mappers;

namespace Repository
{
    public class RegisterMappings
    {
        public void Register()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new ClienteMap());
                config.AddMap(new FilmeMap());
                config.AddMap(new LocacaoMap());
                config.ForDommel();
            });
        }
    }
}