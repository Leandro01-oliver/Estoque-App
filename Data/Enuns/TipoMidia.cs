using System.ComponentModel.DataAnnotations;

namespace Estoque_App.Data.Enuns
{
    public enum TipoMidia
    {
        [Display(Name = "PNG")]
        PNG = 1,
        [Display(Name = "JPEG")]
        JPEG,
        [Display(Name = "SVG")]
        SVG,
    }
}
