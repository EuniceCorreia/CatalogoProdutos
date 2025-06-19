using CatalogoProdutos;
using CatalogoProdutos.DTO;
using Trabalho;
using CatalogoProdutos.Infra;

namespace Services
{
    public class ProdutoDomain
    {
        public DataContext _dataContext;

        public ProdutoDomain()
        {
            _dataContext = GeradorDeServicos.CarregarContexto();
        }

        public void Inserir(InserirProdutoDTO dadosDaInsercao)
        {
            var produto = new Produto();

            produto.Nome = dadosDaInsercao.Nome;
            produto.Descricao = dadosDaInsercao.Descricao;
            produto.Preco = dadosDaInsercao.Preco;
            produto.QtdeEstoque = dadosDaInsercao.QtdeEstoque;
            produto.Tamanho = dadosDaInsercao.Tamanho;
            produto.Disponibilidade = true;

            if (produto.Nome == "") 
            {
                throw new Exception("Falta selecionar o produto");
            }

            _dataContext.Add(produto);

            _dataContext.SaveChanges();
        }

        public void Alterar(int id, EditarProdutoDTO dadosAlteracao)
        {
            var produto = _dataContext.Produtos.FirstOrDefault(p => p.Id == id);

            produto.Preco = dadosAlteracao.Preco;

            _dataContext.SaveChanges();
        }

        public List<Produto> BuscarProduto()
        {
            var listaProdutos = _dataContext.Produtos.ToList();

            return listaProdutos;
        }

        public Produto BuscarPorId(int id)
        {
            var produto = _dataContext.Produtos.First(p => p.Id == id);

            return produto;
        }

        public void Inativar(int id)
        {
            var produto = _dataContext.Produtos.FirstOrDefault(p => p.Id == id);

            produto.Disponibilidade = false;

            _dataContext.SaveChanges();
        }
    }
}
