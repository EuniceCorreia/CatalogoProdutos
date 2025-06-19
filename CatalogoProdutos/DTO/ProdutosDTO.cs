namespace CatalogoProdutos.DTO
{
    public class InserirProdutoDTO
    {

        public string Nome { get; set; }

        public string Tamanho { get; set; }

        public int QtdeEstoque { get; set; }

        public decimal Preco { get; set; }

        public string Descricao { get; set; }
    }

    public class EditarProdutoDTO
    {
        public decimal Preco { get; set; }

    }
}
