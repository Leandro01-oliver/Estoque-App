using Estoque_App.Data.Models;

namespace Estoque_App.Data.Entities
{
    public class Produto
    {
        public Guid ProdutoId { get; private set; } = Guid.NewGuid();
        public Guid? MidiaId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Midia? Midia { get; set; }
    }
}
