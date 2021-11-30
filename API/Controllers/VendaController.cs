using System.Linq;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendaController : ControllerBase
    {
        private readonly DataContext _context;
        public VendaController(DataContext context)
        {
            _context = context;
        }

        //GET: api/venda/list
        //ALTERAR O MÉTODO PARA MOSTRAR TODOS OS DADOS DA VENDA E OS DADOS RELACIONADOS
        [HttpGet]
        [Route("list")]
        public IActionResult List() =>
            Ok(_context.Vendas
            .Include(p => p.Itens)
            .ThenInclude(q => q.Produto.Categoria)
            .ToList());


        [HttpPost]
        [Route("create/{carrinhoId}")]
        public IActionResult Create([FromBody] Venda venda, [FromRoute] string carrinhoId)
        {
            venda.Itens = _context.ItensVenda.Where(p => p.CarrinhoId == carrinhoId).ToList();
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return Created("", venda);
        }
    }
}