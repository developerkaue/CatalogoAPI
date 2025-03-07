namespace CatalogoAPI.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>(); // Lista de Produtos
    }
}
