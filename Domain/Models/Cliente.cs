namespace Domain.Models
{
    public class Cliente : BaseEntity
    {
        public string NomeCompleto { get; set; }

        public string Fone { get; set; }

        public string Email { get; set; }
    }
}