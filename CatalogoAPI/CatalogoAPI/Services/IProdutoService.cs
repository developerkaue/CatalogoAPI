using CatalogoAPI.Models;

namespace CatalogoAPI.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(int id);
        Task AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(int id);
        Task<IEnumerable<Categoria>> GetCategoriasByProdutoIdAsync(int produtoId);
    }
}
