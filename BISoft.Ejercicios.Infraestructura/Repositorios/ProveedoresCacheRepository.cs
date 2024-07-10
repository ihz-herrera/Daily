﻿using BISoft.Ejercicios.Infraestructura.Contextos;
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

        public void CrearProveedor(Proveedor proveedor)
        {
            _proveedoresRepository.CrearProveedor(proveedor);
            InvalidarCache();
        }

        public void EliminarProveedor(int id)
        {
            _proveedoresRepository.EliminarProveedor(id);
            InvalidarCache(id);
            
        }

        public List<Proveedor> ObtenerProveedores()
        {
            var CacheKey = "Proveedores";

            if (_cache.Contains(CacheKey))
            {
                return _cache.Get(CacheKey) as List<Proveedor>;
            }
            else
            {
                var proveedores = _proveedoresRepository.ObtenerProveedores();

                _cache.Set(CacheKey, proveedores, _policy);

                return proveedores;
            }

            
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