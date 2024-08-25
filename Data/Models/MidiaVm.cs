using Estoque_App.Data.Entities;
using Estoque_App.Data.Enuns;

namespace Estoque_App.Data.Models
{
    public class MidiaVm
    {
        public Guid MidiaId { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Url { get; set; }
        public TipoMidia TipoMidia { get; set; }
        public virtual ICollection<Produto> Produtos { get; private set; }

        public void CompletaMidia(string url, IFormFile file)
        {

            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "O arquivo não pode ser nulo");
            }

            string tipoFile = file.ContentType.ToLowerInvariant();

            switch (tipoFile)
            {
                case "image/png":
                    this.TipoMidia = TipoMidia.PNG;
                    break;
                case "image/jpeg":
                    this.TipoMidia = TipoMidia.JPEG;
                    break;
                default:
                    this.TipoMidia = TipoMidia.SVG;
                    break;
            }

            this.Nome = file.FileName;
            this.Url = url;

        }
    }
}
