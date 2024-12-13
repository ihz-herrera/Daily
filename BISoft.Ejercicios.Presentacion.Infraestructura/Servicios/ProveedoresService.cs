using BISoft.Ejercicios.Presentacion.Infraestructura.Contratos;
using BISoft.Ejercicios.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Presentacion.Infraestructura.Servicios
{
    public class ProveedoresService : IProveedoresService
    {


        [Obsolete("Este metodo esta obsoleto, usar el metodo GuardarProveedor(CrearProveedor proveedor)")]
        public async Task<ProveedorDto> GuardarProveedor(string id, string nombre, string direccion)
        {
             var proveedor = new CrearProveedor
                {
                    Nombre = nombre,
                    Direccion = direccion,
                    Telefono = string.Empty
             };
            
            return await GuardarProveedor(proveedor);
        }

        public async Task<ProveedorDto> GuardarProveedor(CrearProveedor proveedor)
        {

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync("https://localhost:44300/api/proveedores",
                proveedor);


            return await response.Content.ReadFromJsonAsync<ProveedorDto>();
        }




        public Task<IEnumerable<ProveedorDto>> ObtenerProveedores()
        {
            throw new NotImplementedException();
        }

        public Task<ProveedorDto> ObtenerProveedorPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
