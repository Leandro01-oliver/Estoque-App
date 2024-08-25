namespace Estoque_App.Data.Models
{
    public class ProdutoVm
    {
        public Guid ProdutoId { get;  set; } 
        public Guid MidiaId { get;  set; } 
        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public MidiaVm MidiaVm { get; set; }
    }
}
