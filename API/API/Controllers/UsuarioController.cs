using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext context;

        public UsuarioController (DataContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task <ActionResult<List<Usuario>>> Get()
        {
            return Ok(await context.Usuario.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task <ActionResult<Usuario>> Get(long id)
        {
            var usuario = await context.Usuario.FindAsync(id);
            if (usuario == null)
                return BadRequest("Usuario no encontrado.");
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<List<Usuario>>> AddUser(Usuario user)
        {
            context.Usuario.Add(user);
            await context.SaveChangesAsync();
            return Ok(await context.Usuario.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Usuario>>> UpdateUser(Usuario requestuser)
        {
            var usuario = await context.Usuario.FindAsync(requestuser.Id);
            if (usuario == null)
                return BadRequest("Usuario no encontrado");

            usuario.Nombre = requestuser.Nombre;
            usuario.Apellido = requestuser.Apellido;
            usuario.NombreUsuario = requestuser.NombreUsuario;
            usuario.Contraseña = requestuser.Contraseña;
            usuario.Mail = requestuser.Mail;
            await context.SaveChangesAsync();
            return Ok(await context.Usuario.ToListAsync());

        }
        [HttpDelete]
        public async Task<ActionResult<List<Usuario>>> DeleteUser(long id)
        {
            var usuario = await context.Usuario.FindAsync(id);
            if (usuario == null)
                return BadRequest("Usuario no encontrado");
            context.Usuario.Remove(usuario); 
            await context.SaveChangesAsync();
            return Ok(await context.Usuario.ToListAsync());
        }
    }
}
