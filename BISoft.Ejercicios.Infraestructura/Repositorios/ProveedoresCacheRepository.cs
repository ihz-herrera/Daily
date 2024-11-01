using BISoft.Ejercicios.Dominio.Contratos;
using BISoft.Ejercicios.Dominio.Entidades;
using System.Linq.Expressions;
using System.Runtime.Caching;

namespace BISoft.Ejercicios.Infraestructura.Repositorios
{
    public class ProveedoresCacheRepository : IProveedoresRepository
    {
        private MemoryCache _cache;
        private CacheItemPolicy _policy;
        private readonly ProveedoresRepository _proveedoresRepository;

        public ProveedoresCacheRepository(ProveedoresRepository proveedoresRepository)
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

        public async Task Actualizar(Proveedor proveedor)
        {
            await _proveedoresRepository.Actualizar(proveedor);
            InvalidarCache(proveedor.Id);
        }

        private void InvalidarCache(int id)
        {
            var CacheKey = $"Proveedor:{id}";


            if (_cache.Contains(CacheKey))
            {
                 _cache.Remove(CacheKey);
            }

            InvalidarCache();
        }

        private void InvalidarCache()
        {
            var CacheKey = "Proveedores";

            if (_cache.Contains(CacheKey))
            {
                _cache.Remove(CacheKey);
            }


        }

        public async Task Crear(Proveedor proveedor)
        {
            await _proveedoresRepository.Crear(proveedor);
            InvalidarCache();
        }

        public void EliminarProveedor(int id)
        {
            _proveedoresRepository.EliminarProveedor(id);
            InvalidarCache(id);
            
        }

        public async Task<List<Proveedor>> ObtenerTodos()
        {
            var CacheKey = "Proveedores";

            if (_cache.Contains(CacheKey))
            {
                return _cache.Get(CacheKey) as List<Proveedor>;
            }
            else
            {
                var proveedores = await _proveedoresRepository.ObtenerTodos();

                _cache.Set(CacheKey, proveedores, _policy);

                return proveedores;
            }

            
        }

        public async Task<Proveedor> ObtenerProveedorPorId(int id)
        {

            var CacheKey = $"Proveedor:{id}";


            if (_cache.Contains(CacheKey))
            {
                return _cache.Get(CacheKey) as Proveedor;
            }
            else
            {
                var proveedor = await _proveedoresRepository.ObtenerProveedorPorId(id);

                _cache.Set(CacheKey, proveedor, _policy);

                return proveedor;
            }
        }

        public async Task<Proveedor> ObtenerPorExpresion(Expression<Func<Proveedor, bool>> expresion)
        {
            return await _proveedoresRepository.ObtenerPorExpresion(expresion);
        }

        public IQueryable<Proveedor> GetCollectionByExp(Expression<Func<Proveedor, bool>> expresion)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Proveedor> GetCollection()
        {
            return _proveedoresRepository.GetCollection();
        }
    }
}
