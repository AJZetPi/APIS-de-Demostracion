using APIDOS.Context;
using APIDOS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace APIDOS.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext context;
        public UsuarioController (DataContext contexto)
        {
            this.context = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            return Ok(await context.Usuario.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios(long id)
        {
            var usuario = await context.Usuario.FindAsync(id);
            if (usuario == null)
                return BadRequest("Usuario no encontrado");
            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult<List<Usuario>>> AddUsuario(Usuario user)
        {
            context.Usuario.Add(user);
            await context.SaveChangesAsync();
            return Ok(await context.Usuario.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult<List<Usuario>>> DeleteUsuario (long id)
        {
            var usuario = await context.Usuario.FindAsync(id);
            if (usuario == null)
                return BadRequest("Usuario no encontrado");
            context.Usuario.Remove(usuario);
            await context.SaveChangesAsync();
            return Ok(await context.Usuario.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Usuario>>> PutUsuario (Usuario requestuser)
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
    }
}
