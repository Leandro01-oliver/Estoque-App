using Estoque_App.Data.Enuns;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque_App.Data.Entities
{
    public class Midia
    {
        public Guid MidiaId { get; private set; } = Guid.NewGuid();
        public string Nome { get; private set; }
        public string Url { get; private set; }
        public TipoMidia TipoMidia { get; private set; }
        public virtual ICollection<Produto> Produtos { get; private set; }
    }
}
