using System;

namespace Domain.Models
{
    public class Reserva : BaseEntity
    {
        public Reserva()
        {
            DataReserva = DateTime.Now;
        }

        public DateTime DataReserva { get; set; }

        public int idCliente { get; set; }
        public int idFilme { get; set; }

        public Cliente Cliente { get; set; }

        public Filme Filme { get; set; }
    }
}