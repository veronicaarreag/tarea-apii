using Microsoft.EntityFrameworkCore;
namespace web_api_1.Models
{
    class Conexion : DbContext{
        public Conexion (DbContextOptions<Conexion> options) : base (options){}
        public DbSet<Clientes> Clientes {get;set;}

    }
    
    class Conectar{
        private const string cadenaConexion ="server=localhost; port=3306;database=db_empresa;userid=root;pwd=49142112";
        
        public static Conexion Create{
            var contructor = new DbContextBuilder<Conexion>();
            contructor.UseMySQL(cadenaConexion);
            var cn = new Conexion(contructor.Options);
            return cn;
            }
    }
}