using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BISoft.Ejercicios.Aplicacion.Helpers
{
    public class PagerList<T> : List<T>
    {
        private const int MaxPageSize = 100;
        private IQueryable<T> _source;

        public int TotalCount { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;



        public async Task Next()
        {
            if(HasNextPage)
            {
                PageIndex++;

                var items = await _source
                    .Skip((PageIndex - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();
                Clear();
                AddRange(items);
            }
        }

        public async Task Previus() 
        {             
            if(HasPreviousPage)
            {
                PageIndex--;

                var items = await _source
                    .Skip((PageIndex - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();
                Clear();
                AddRange(items);
            }
        }

        public async Task LoadMore()
        {
            if (HasNextPage)
            {
                PageIndex++;

                var items = await _source
                    .Skip((PageIndex - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();
                
                AddRange(items);
            }
        }

        private PagerList(List<T> items, int count, int pageIndex, int pageSize, IQueryable<T> source)
        {
            TotalCount = count;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
            
            _source = source;
        }



        public static async Task<PagerList<T>> Create(IQueryable<T> source, int pageIndex, int pageSize)
        {

            if(pageSize <= 0)
            {
                pageSize = 10;
            }

            if(pageSize > MaxPageSize)
            {
                pageSize = MaxPageSize;
            }

            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagerList<T>(items, count, pageIndex, pageSize,source);
        }


    }
}
