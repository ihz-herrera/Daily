using BISoft.Ejercicios.Infraestructura.Contextos;
using BISoft.Ejercicios.Infraestructura.Contratos;
using BISoft.Ejercicios.Infraestructura.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class ProveedoresCacheRepository : IProveedoresRepository
    {
        private MemoryCache _cache;
        private CacheItemPolicy _policy;
        private readonly IProveedoresRepository _proveedoresRepository;

        public ProveedoresCacheRepository(IProveedoresRepository proveedoresRepository)
        {
            _proveedoresRepository = proveedoresRepository;
            InicializarCache();
        }

        private void InicializarCache()
        {
            _cache = MemoryCache.Default;
            _policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60)
            };
        }

        public void ActualizarProveedor(Proveedor proveedor)
        {
            _proveedoresRepository.ActualizarProveedor(proveedor);
        }

        public void CrearProveedor(Proveedor proveedor)
        {
            _proveedoresRepository.CrearProveedor(proveedor);
        }

        public void EliminarProveedor(int id)
        {
            _proveedoresRepository.EliminarProveedor(id);
        }

        public List<Proveedor> ObtenerProveedores()
        {
            return _proveedoresRepository.ObtenerProveedores();
        }

        public Proveedor ObtenerProveedorPorId(int id)
        {

            var CacheKey = $"Proveedor:{id}";


            if (_cache.Contains(CacheKey))
            {
                return _cache.Get(CacheKey) as Proveedor;
            }
            else
            {
                var proveedor = _proveedoresRepository.ObtenerProveedorPorId(id);

                _cache.Set(CacheKey, proveedor, _policy);

                return proveedor;
            }
        }
    }
}
