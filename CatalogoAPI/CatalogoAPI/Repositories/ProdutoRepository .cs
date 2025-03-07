using CatalogoAPI.Data;
using CatalogoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoAPI.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _context.Produtos.Include(p => p.Categoria).ToListAsync();
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            return await _context.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Produto produto)
        {
            var categoriaExistente = await _context.Categorias.AnyAsync(c => c.Id == produto.CategoriaId);
            if (!categoriaExistente)
            {
                throw new InvalidOperationException("A categoria especificada não existe.");
            }

            var produtoExistente = await _context.Produtos.AnyAsync(p => p.Nome == produto.Nome);
            if (produtoExistente)
            {
                throw new InvalidOperationException("Já existe um produto com o mesmo nome.");
            }

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasByProdutoIdAsync(int produtoId)
        {
            var produto = await _context.Produtos
                                       .Include(p => p.Categoria) // Categoria é uma entidade relacionada
                                       .FirstOrDefaultAsync(p => p.Id == produtoId);

            return produto != null ? new List<Categoria> { produto.Categoria } : Enumerable.Empty<Categoria>();
        }
    }
}
