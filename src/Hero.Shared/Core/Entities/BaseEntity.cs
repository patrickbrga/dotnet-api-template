namespace Shared.Core.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public bool Deletado { get; set; }
        public DateTime DataCadastro { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            Ativo = true;
            Deletado = false;
            DataCadastro = DateTime.Now;
        }
    }
}
