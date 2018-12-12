using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DatingApp.WebApiService
{
    public static class Extension
    {
        /// <summary>
        /// Async create of a System.Collections.Generic.List<T> from an 
        /// System.Collections.Generic.IQueryable<T>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="list">The System.Collections.Generic.IEnumerable<T> 
        /// to create a System.Collections.Generic.List<T> from.</param>
        /// <returns> A System.Collections.Generic.List<T> that contains elements 
        /// from the input sequence.</returns>
        public static Task<List<T>> ToListAsync<T>(this IQueryable<T> list)
        {
            return Task.Run(() => list.ToList());
        }

        public static Task<List<T>> ToListAsync<T>(this IEnumerable<T> list)
        {
            return Task.Run(() => list.ToList());
        }

        public static Task<T> FirstOrDefaultAsync<T>(this IEnumerable<T> list, Func<T, bool> predicate)
        {
            return Task.Run(() => list.FirstOrDefault<T>(predicate));
        }
    }
}