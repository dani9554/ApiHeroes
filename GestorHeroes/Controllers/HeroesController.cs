using GestorHeroes.Data;
using GestorHeroes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestorHeroes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroesController : ControllerBase
    {
        private JuegoContext _context;

        public HeroesController(JuegoContext context)
        {
            _context = context;
        }

        // GET: /heroes
        [HttpGet]
        public async Task<ActionResult> GetPersonajes()
        {
            var personajes = await _context.Personajes.ToListAsync();

            var resultado = personajes.Select(p => ConvertPersonaje(p));

            return Ok(resultado);
        }
        private object ConvertPersonaje(Personaje p)
        {
            if (p is Guerrero g)
            {
                return new
                {
                    p.Id,
                    p.Nombre,
                    p.Nivel,
                    p.FechaCreacion,
                    p.Gremio,
                    p.Rasgos,
                    g.ArmaPrincipal,
                    g.Furia
                };
            }

            if (p is Mago m)
            {
                return new
                {
                    p.Id,
                    p.Nombre,
                    p.Nivel,
                    p.FechaCreacion,
                    p.Gremio,
                    p.Rasgos,
                    m.Mana,
                    m.ElementoPrincipal
                };
            }

            if (p is Arquero a)
            {
                return new
                {
                    p.Id,
                    p.Nombre,
                    p.Nivel,
                    p.FechaCreacion,
                    p.Gremio,
                    p.Rasgos,
                    a.Precision,
                    a.TieneMascota
                };
            }

            if (p is Clerigo c)
            {
                return new
                {
                    p.Id,
                    p.Nombre,
                    p.Nivel,
                    p.FechaCreacion,
                    p.Gremio,
                    p.Rasgos,
                    c.Deidad,
                    c.PuntosSanacion
                };
            }

            return new
            {
                p.Id,
                p.Nombre,
                p.Nivel,
                p.FechaCreacion,
                p.Gremio,
                p.Rasgos
            };
        }

        // GET: /heroes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Personaje>> GetHeroe(int id)
        {
            var heroe = await _context.Personajes.FindAsync(id);
            if (heroe == null)
            {
                return NotFound();
            }
            return Ok(heroe);
        }

        // DELETE: /heroes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroe(int id)
        {
            var heroe = await _context.Personajes.FindAsync(id);
            if (heroe == null)
            {
                return NotFound();
            }
            _context.Personajes.Remove(heroe);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                mensaje = $"Personaje eliminado correctamente con id {id}",
            });
        }

        // POST: /heroes
        [HttpPost]
        public async Task<ActionResult<Personaje>> CreateHeroe([FromBody] PersonajeDTO heroe)
        {
            Personaje nuevoHeroe;
            if (!string.IsNullOrEmpty(heroe.ArmaPrincipal) || heroe.Furia.HasValue)
            {
                nuevoHeroe = new Guerrero
                {
                    Nombre = heroe.Nombre,
                    Nivel = heroe.Nivel,
                    FechaCreacion = DateTime.UtcNow,
                    Gremio = heroe.Gremio,
                    Rasgos = heroe.Rasgos,
                    ArmaPrincipal = heroe.ArmaPrincipal!,
                    Furia = heroe.Furia ?? 0,
                };
            } else if (heroe.Precision.HasValue || heroe.TieneMascota.HasValue)
            {
                nuevoHeroe = new Arquero
                {
                    Nombre = heroe.Nombre,
                    Nivel = heroe.Nivel,
                    FechaCreacion = DateTime.UtcNow,
                    Gremio = heroe.Gremio,
                    Rasgos = heroe.Rasgos,
                    Precision = heroe.Precision ?? 0,
                    TieneMascota = heroe.TieneMascota ?? false,
                };
            } else if (!string.IsNullOrEmpty(heroe.Deidad) || heroe.PuntosSanacion.HasValue)
            {
                nuevoHeroe = new Clerigo
                {
                    Nombre = heroe.Nombre,
                    Nivel = heroe.Nivel,
                    FechaCreacion = DateTime.UtcNow,
                    Gremio = heroe.Gremio,
                    Rasgos = heroe.Rasgos,
                    Deidad = heroe.Deidad!,
                    PuntosSanacion = heroe.PuntosSanacion ?? 0,
                };
            } else if (heroe.Mana.HasValue || !string.IsNullOrEmpty(heroe.ElementoPrincipal))
            {
                nuevoHeroe = new Mago
                {
                    Nombre = heroe.Nombre,
                    Nivel = heroe.Nivel,
                    FechaCreacion = DateTime.UtcNow,
                    Gremio = heroe.Gremio,
                    Rasgos = heroe.Rasgos,
                    Mana = heroe.Mana ?? 0,
                    ElementoPrincipal = heroe.ElementoPrincipal!,
                };
            } else
            {
                return BadRequest("No se pudo determinar la clase del personaje.");
            }
            
            _context.Personajes.Add(nuevoHeroe);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHeroe), new { id = nuevoHeroe.Id }, nuevoHeroe);
        }
        // PUT: /heroes/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Personaje>> UpdateHeroe(int id, [FromBody] PersonajeDTO heroe)
        {
            var heroeExistente = await _context.Personajes.FindAsync(id);
            if (heroeExistente == null)
            {
                return NotFound();
            }
            heroeExistente.Nombre = heroe.Nombre;
            heroeExistente.Nivel = heroe.Nivel;
            heroeExistente.Gremio = heroe.Gremio;
            heroeExistente.Rasgos = heroe.Rasgos;
            if (heroeExistente is Guerrero guerrero)
            {
                guerrero.ArmaPrincipal = heroe.ArmaPrincipal ?? guerrero.ArmaPrincipal;
                guerrero.Furia = heroe.Furia ?? guerrero.Furia;
            }
            else if (heroeExistente is Arquero arquero)
            {
                arquero.Precision = heroe.Precision ?? arquero.Precision;
                arquero.TieneMascota = heroe.TieneMascota ?? arquero.TieneMascota;
            }
            else if (heroeExistente is Clerigo clerigo)
            {
                clerigo.Deidad = heroe.Deidad ?? clerigo.Deidad;
                clerigo.PuntosSanacion = heroe.PuntosSanacion ?? clerigo.PuntosSanacion;
            }
            else if (heroeExistente is Mago mago)
            {
                mago.Mana = heroe.Mana ?? mago.Mana;
                mago.ElementoPrincipal = heroe.ElementoPrincipal ?? mago.ElementoPrincipal;
            }
            await _context.SaveChangesAsync();
            return Ok(heroeExistente);
        }
    }
}
