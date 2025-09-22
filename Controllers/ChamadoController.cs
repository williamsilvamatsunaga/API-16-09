using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiServico.Models.Duo;
using ApiServico.Models;
using ApiServico.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace ApiServico.Controllers
{
    [Route("/chamados")]
    [ApiController]
    public class ChamadoController : ControllerBase
    {

        private readonly AppDbContext _context;

        public ChamadoController(AppDbContext context)
        {
            _context = context;
        }

        private static int _proximoId = 3;

        [HttpGet]
        public async Task<IActionResult> BuscarTodos()
        {
            var chamados = await _context.Chamados.ToListAsync();

            return Ok(chamados);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> BuscarPorId(int id)
        {
            var chamado = await _context.Chamados.FirstOrDefaultAsync(x => x.Id == id);

         

            return Ok(chamado);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ChamadoDuo novoChamado)
        {
            var chamado = new Chamado()
            { 
                Titulo = novoChamado.Titulo,
                Descricao = novoChamado.Descricao
            };

            await _context.Chamados.AddAsync(chamado);
            await _context.SaveChangesAsync();
            

            return Created("", chamado);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Remover(int id)
        {

            var chamado = await _context.Chamados.FirstOrDefaultAsync(x => x.Id == id);

            if (chamado is null)
            {
                return NotFound();
            }

            _context.Chamados.Remove(chamado);
            await _context.SaveChangesAsync();

            return Ok(chamado);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Atualizar(int id, [FromBody] ChamadoDuo atualizarChamado)
        {
            var chamado = await _context.Chamados.FirstOrDefaultAsync(x => x.Id == id);

            if (chamado is null)
            {
                return NotFound();
            }

            chamado.Titulo = atualizarChamado.Titulo;
            chamado.Descricao = atualizarChamado.Descricao;

            _context.Chamados.Update(chamado);
            await _context.SaveChangesAsync();

            return Ok(chamado);
        }

        [HttpPut("{id}/Encerrar")]

        public IActionResult Fechar(int id)
        {
            
            

            return Ok();
        }
    }
}