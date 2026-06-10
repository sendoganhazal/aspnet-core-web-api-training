using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repositories.Extensions
{
    public static class BooksRepositoryExtensions
    {
        public static IQueryable<Book> FilterBooks ( this IQueryable<Book> books,
            uint minPrice, uint maxPrice ) =>
            books.Where ( b => b.Price >= minPrice && b.Price <= maxPrice );
        public static IQueryable<Book> Search ( this IQueryable<Book> books,
            string? searchTerm )
        {
            if ( string.IsNullOrWhiteSpace ( searchTerm ) )
                return books;
            var lowerCaseSearchTerm = searchTerm.Trim ( ).ToLower ( ); // BlAcK -> black
            return books.Where ( b => b.Title.ToLower ( ).Contains ( lowerCaseSearchTerm ) );
        }
        public static IQueryable<Book> Sort ( this IQueryable<Book> books,
            string orderByQueryString )
        {
            if ( string.IsNullOrWhiteSpace ( orderByQueryString ) )
                return books.OrderBy ( b => b.Id );
            var orderParams = orderByQueryString.Trim ( ).Split ( ',' );
            var propertyInfos = typeof ( Book ).GetProperties (
                BindingFlags.Public |
                BindingFlags.Instance
            );

            var orderQueryBuilder = new StringBuilder ( );

            foreach ( var param in orderParams )
            {
                if ( string.IsNullOrWhiteSpace ( param ) )
                    continue;
                var propertyFromQueryName = param.Split ( ' ' )[0];
                var objectProperty = propertyInfos
                    .FirstOrDefault ( pi => pi.Name.Equals ( propertyFromQueryName,
                    StringComparison.InvariantCultureIgnoreCase ) );

                if ( objectProperty is null )
                    continue;

                var direction = param.EndsWith ( " desc" ) ? "descending" : "ascending";

                orderQueryBuilder.Append ( $"{objectProperty.Name} {direction}," );
            }

            var orderQuery = orderQueryBuilder.ToString ( ).TrimEnd ( ',', ' ' );

            if ( string.IsNullOrWhiteSpace ( orderQuery ) )
                return books.OrderBy ( b => b.Id );

            return books.OrderBy ( orderQuery );
        }
    }
}