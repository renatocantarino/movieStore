using System;

namespace Domain.Models
{
    public class Locacao : BaseEntity
    {
        public Locacao()
        {
            DataLocacao = DateTime.Now;
            DataDevolucao = DataLocacao.AddDays(3);
        }

        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }

        public int idCliente { get; set; }
        public int idFilme { get; set; }

        public Cliente Cliente { get; set; }

        public Filme Filme { get; set; }
    }
}