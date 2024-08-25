using Estoque_App.Data.Enuns;

namespace Estoque_App.Data.Models
{
    public class ProdutoVm
    {
        public Guid ProdutoId { get;  set; } 
        public Guid? MidiaId { get;  set; } 
        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public MidiaVm? MidiaVm { get; set; }

        public static TipoMidia CheckMidia(string tipoMidia)
        {
            TipoMidia tipoMidiaEnum = new TipoMidia();
            switch (tipoMidia)
            {
                case "image/png":
                    tipoMidiaEnum = TipoMidia.PNG;
                    break;
                case "image/jpeg":
                    tipoMidiaEnum = TipoMidia.JPEG;
                    break;
                default:
                    tipoMidiaEnum = TipoMidia.SVG;
                    break;
            }

            return tipoMidiaEnum;
        }
   }
}
