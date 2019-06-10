using Domain.Models;
using System.Linq;

namespace Repository.Repositories
{
    public class ReservaRepository : RepositoryBase<Reserva>
    {
        public void AvisarClienteFilmeDisponivel(Reserva reserva)
        {
            try
            {
                var _reserva = GetList(x => x.idFilme == reserva.idFilme).FirstOrDefault();
                if (reserva != null)
                {
                    //Fluxo de Envio de Email ou notificação no celular.
                    //delete reserva
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}