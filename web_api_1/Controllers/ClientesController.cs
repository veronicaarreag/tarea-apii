using Microsoft.AspNetCore.Mvc;
using System.Linq;
using web_api_1.Models;
using System.Threading.Task;


namespace web_api_1.Controllers{
[Route ("api/[Controller]")]
public class ClientesController : Controller{
    
    
    private Conexion dbConexion;
    public ClientesController(){
        dbConexion = Conectar.Create();
    }
    [HttpGet]

    public ActionResult Get(){
        return Ok(dbConexion.Clientes.ToArray());
    }

    [HttpGet("{id}")]
        public async Task<ActionResult>Get(int id){
            var clientes = await dbConexion.Clientes.FindAsync(id);
            if (clientes !=null){
                return Ok(clientes);
            }else{
                return NotFound(clientes);
            }
        }
        //Post se usa para enviar datos
        [HttpPost]
        public async Task<ActionResult>Post([FromBody] Clientes clientes){
            if (ModelState.IsValid){
                dbConexion.Clientes.Add(clientes);
                await dbConexion.SaveChangesAsync();
                return Ok();
            }else {
                return BadRequest();
            }
        }
        //Put cambia datos
        public async Task<ActionResult> Put([FromBody] Clientes clientes){
            var v_clientes = dbConexion.Clientes.SingleOrDefault(a => a.id_cliente == clientes.id_cliente);
            if (v_clientes != null && ModelState.IsValid){
                dbConexion.Entry(v_clientes).CurrentValues.SetValues(clientes);
                await dbConexion.SaveChangesAsync();
                return Ok();
            }else{
                return BadRequest();
            }
        }
        //Elimina Datos
        [HttpDelete("{id}")]
        public async Task<ActionResult>Delete(int id){
            var clientes = dbConexion.Clientes.SingleOrDefault(a => a.id_cliente == id);
            if (clientes !=null){
                dbConexion.Clientes.Remove(clientes);
                dbConexion.SaveChangesAsync();
                return Ok();
            }else{
                return BadRequest();
            }
        }

}

}