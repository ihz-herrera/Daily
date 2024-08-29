using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Servicios
{
    public class ComprasService
    {

        private readonly IComprasRepository _comprasRepository;

        public ComprasService(IComprasRepository comprasRepository)
        {
            _comprasRepository = comprasRepository;
        }

        public async Task CrearCompra(Compra compra)
        {
            await _comprasRepository.Crear(compra);
        }

        public async Task<List<Compra>> ObtenerCompras()
        {
            return await _comprasRepository.ObtenerTodos();
        }

        public async Task<Compra> ObtenerCompraPorId(int id)
        {
            return await _comprasRepository.ObtenerPorExpresion(x => x.CompraId == id);
        }

        public async Task ActualizarCompra(Compra compra)
        {
            await _comprasRepository.Actualizar(compra);
        }

        public async Task Cancelar(int id)
        {
            //Cambiar status

            //Actualizar Fecha Actualizacion

            //Actualizar Usuario Actualizacion

            //Agregar Motivo de Cancelacion

            //Crear una nota de credito

            //Afectar el inventario

            //Actualizar los saldos de proveedores

            //Notificar a los interesados

            await Task.CompletedTask;
        }

    }
}
