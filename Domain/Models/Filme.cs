namespace Domain.Models
{
    public class Filme : BaseEntity
    {
        public int AnoLancamento { get; set; }

        public string Resumo { get; set; }

        public string Caminho { get; set; }

        public string Nome { get; set; }

        public bool Alugado { get; set; }
    }
}