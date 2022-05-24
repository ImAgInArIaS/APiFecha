using Microsoft.AspNetCore.Mvc;
using ApiBaseDatos.Models;
using ApiBaseDatos.Resultados.Usuarios;
using ApiBaseDatos.Comandos.Usuarios;
using Microsoft.EntityFrameworkCore;
namespace ApiBaseDatos.Controllers;

[ApiController]
public class UsuarioController: ControllerBase 
{
    private readonly Prog31105Context _context;

    public UsuarioController(Prog31105Context context){

        _context = context;
    }

    [HttpPost]
    [Route("ApiBaseDatos/usuario/login")]
    public async Task<ActionResult<ResultadoLogin>> Login([FromBody]ComandoLogin comando)
    {
        try 
        {
            var result = new ResultadoLogin();
            //var usuarios = await _context.Usuarios.ToListAsync();
            var usuario = await  _context.Usuarios.Where(c=>c.Activo && c.NombreUsuario.Equals(comando.NombreDeUsuario) && c.Password.Equals(comando.Password)).Include(c=>c.IDrollNavigation).FirstOrDefaultAsync();
            if(usuario != null)
            {
                result.NombreDeUsuario = usuario.NombreUsuario;
                result.NombreRol = usuario.IDrollNavigation.Nombre;
                result.StatusCode = "200";
                return Ok(result);
            }
            else 
            {
                result.SetError("Usuario no encontrado en la base de datos...");
                result.StatusCode ="500";
                return Ok(result);
            }
        }
         catch (Exception ex)
         {
             return BadRequest("Error al obtener el usuario");
         }
    }

    [HttpPost]
    [Route("ApiBaseDatos/usuario/create")]
    public async Task<ActionResult<bool>> CreateUsuario([FromBody]ComandCreateUsuario comando)
    {
        try 
        {
           var usuario = new Usuario{
               Id = Guid.NewGuid(),
               Activo = true,
               FechaAlta = new DateOnly(), 
               IDroll = new Guid("cb8f0c89-f0de-4a05-8d42-dad161269c3e"),
               NombreUsuario = comando.NombreUsuario,
               Password = comando.Password

           };
           await _context.AddAsync(usuario);
           await _context.SaveChangesAsync();
           return Ok(true);

        }
         catch (Exception ex)
         {
             return BadRequest("Error al Generar el usuario");
         }
    }
     [HttpGet]
    [Route("ApiBaseDatos/usuario/GetTodos")]
    public async Task<ActionResult<List<ResultadoLogin>>> GetTodosLosActivos()
    {
        try 
        {
            var result = new List<ResultadoLogin>();
            //var usuarios = await _context.Usuarios.ToListAsync();
            var usuarios = await  _context.Usuarios.Where(c=>c.Activo).Include(c=>c.IDrollNavigation).ToListAsync();
            if(usuarios != null)
            {
                foreach(var usu in usuarios)
                {
                     var resultAux = new ResultadoLogin{
                    NombreDeUsuario = usu.NombreUsuario,
                    NombreRol = usu.IDrollNavigation.Nombre,
                    StatusCode = "200"
                    
                };
                result.Add(resultAux);               

                }
                
                return Ok(result);
            }
            else 
            {
               
                return Ok(result);
            }
        }
         catch (Exception ex)
         {
             return BadRequest("Error al obtener el usuario");
         }
    }
}
