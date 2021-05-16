using System.ComponentModel.DataAnnotations.Schema;

namespace Macoratti.RepositoryPattern.Api.Domain
{
    [Table("Cliente")]
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
