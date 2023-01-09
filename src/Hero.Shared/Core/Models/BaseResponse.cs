namespace Shared.Core.Models
{
    public class BaseResponse
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public bool Deletado { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
