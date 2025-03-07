﻿using CatalogoAPI.Models;

namespace CatalogoAPI.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(int id);
        Task AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(int id);
        Task<IEnumerable<Categoria>> GetCategoriasByProdutoIdAsync(int produtoId);
    }
}
