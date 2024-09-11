using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
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
        private readonly IProductosRepository _productosRepository;

        public ComprasService(IComprasRepository comprasRepository, IProductosRepository productosRepository)
        {
            _comprasRepository = comprasRepository;
            _productosRepository = productosRepository;
        }

        public async Task CrearCompra(Compra compra)
        {
            await _comprasRepository.Crear(compra);
        }

        public async Task<List<Compra>> ObtenerCompras()
        {
            return await _comprasRepository.ObtenerComprasConDetalle();
        }

        public async Task<List<Producto>> ProductosPermitidos(int sucursalId)
        {
            var productosPermitidos = _comprasRepository.ProductosPermitidosCompras();
            var productos = _productosRepository.ObtenerProductos();

            //productos.Where(p=> productosPermitidos.Any(
            //    pp => pp.ProductoId == p.ProductoId
            //    && pp.SucursalId == sucursalId));

            var productosPermitidosResult = from p in productos
                                            join pp in productosPermitidos on p.ProductoId equals pp.ProductoId
                                            where pp.SucursalId == sucursalId && p.Status == true
                                            select p;

            return await productosPermitidosResult.ToListAsync();

        }

        public async Task<Compra> ObtenerCompraPorId(int id)
        {
            return await _comprasRepository
                .ObtenerCompraConDetalle(id);
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
