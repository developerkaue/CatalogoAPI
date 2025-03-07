using CatalogoAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public int CategoriaId { get; set; } // Chave estrangeira

    [JsonIgnore] // Ignora a propriedade Categoria durante a serialização/desserialização
    [NotMapped] // Ignora a propriedade Categoria no mapeamento do Entity Framework Core
    public Categoria Categoria { get; set; } // Propriedade de navegação
}