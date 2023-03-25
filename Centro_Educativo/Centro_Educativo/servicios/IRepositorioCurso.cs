using Centro_Educativo.Models;

namespace Centro_Educativo.servicios
{
    public interface IRepositorioCurso
    {
        IEnumerable<Curso> ObtenerPorEstado(int estado);
    }
}