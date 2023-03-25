using Centro_Educativo.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Centro_Educativo.servicios
{
    public class RepositorioCurso : IRepositorioCurso
    {
        private readonly string connectionSrting;

        public RepositorioCurso(IConfiguration configuration)
        {
            connectionSrting = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Curso> ObtenerPorEstado(int estado)
        {
            using var conexion = new SqlConnection(connectionSrting);
            return conexion.Query<Curso>("SELECT * FROM Curso WHERE BHABILITADO = @Estado", new { estado });

        }
    }
}
