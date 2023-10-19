using ProdutosApi.Data.Contexts;
using ProdutosApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApi.Data.Repositories
{
    public class ProdutoRepository
    {
        public void Add(Produto produto)
        {
            using (var context = new DataContext())
            {
                context.Produto.Add(produto);
                context.SaveChanges();
            }
        }
        public void Update(Produto produto)
        {
            using (var context = new DataContext())
            {
                context.Produto.Update(produto);
                context.SaveChanges();
            }
        }
        public void Delete(Produto produto)
        {
            using (var context = new DataContext())
            {
                context.Remove(produto);
                context.SaveChanges();
            }
        }

        public Produto? Get(Guid id)
        {
            using (var context = new DataContext())
            {
                return context.Produto.Find(id);
            }
        }
        public List<Produto> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Produto.OrderBy(a => a.Nome).ToList();
            }
        }
    }
}
