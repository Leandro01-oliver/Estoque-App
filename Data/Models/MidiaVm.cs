using Estoque_App.Data.Enuns;

namespace Estoque_App.Data.Models
{
    public class MidiaVm
    {
        public Guid MidiaId { get; set; }
        public string Url { get; set; }
        public TipoMidia TipoMidia { get; set; }
    }
}
