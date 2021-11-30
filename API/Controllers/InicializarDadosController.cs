using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { CategoriaId = 1, Nome = "Alimento" },
                    new Categoria { CategoriaId = 2, Nome = "Bebida" },
                    new Categoria { CategoriaId = 3, Nome = "Vestuário" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, NomeProduto = "Cebola", Preco = 5, Quantidade = 3, CategoriaId = 1 },
                    new Produto { ProdutoId = 2, NomeProduto = "Leite", Preco = 3, Quantidade = 1, CategoriaId = 2 },
                    new Produto { ProdutoId = 3, NomeProduto = "Calça Jeans", Preco = 100, Quantidade = 1, CategoriaId = 3 },
                }
            );
            _context.Pagamentos.AddRange(new Pagamento[]
                {
                    new Pagamento { PagamentoId = 1, NumeroDeVezes = 0, FormaDePagamento = "Boleto"},
                    new Pagamento { PagamentoId = 2, NumeroDeVezes = 3, FormaDePagamento = "Cartão de Crédito"},
                    new Pagamento { PagamentoId = 3, NumeroDeVezes = 0, FormaDePagamento = "Cartão de Débito"},
                    new Pagamento { PagamentoId = 4, NumeroDeVezes = 0, FormaDePagamento = "Dinheiro"}
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}