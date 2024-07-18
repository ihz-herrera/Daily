using BISoft.Ejercicios.Infraestructura.Contratos;
using BISoft.Ejercicios.Infraestructura.Entidades;

namespace BISoft.Ejercicios.Aplicacion.Servicios
{
    public class ProveedoresService
    {
        private readonly IProveedoresRepository _repo;

        public ProveedoresService(IProveedoresRepository repo)
        {
            _repo = repo;
        }


        public async Task GuardarProveedor(short id, string nombre, string direccion)
        {

            // Consultar si el proveedor ya existe
            var proveedor = await _repo.ObtenerProveedorPorId(id);
            if (proveedor != null)
            {
                //si existe, actualizar
                proveedor = new Proveedor
                {
                    Id = id,
                    Nombre = nombre,
                    Direccion = direccion
                };

                await _repo.Actualizar(proveedor);
            }
            else
            {
                //si no existe, crear
                proveedor = new Proveedor
                {
                    Id = id,
                    Nombre = nombre,
                    Direccion = direccion
                };

                await _repo.Crear(proveedor);
            }



        }
    
        public async Task<IEnumerable<Proveedor>> ObtenerProveedores()
        {
            return await _repo.ObtenerTodos();
        }
    
    }
}
