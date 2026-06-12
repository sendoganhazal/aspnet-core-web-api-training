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
            string OrderByQueryString )
        {
            if ( string.IsNullOrWhiteSpace ( OrderByQueryString ) )
                return books.OrderBy ( b => b.Id );

            var orderQuery = OrderQueryBuilder
                .CreateOrderQuery<Book>(OrderByQueryString);

            if ( string.IsNullOrWhiteSpace ( orderQuery ) )
                return books.OrderBy ( b => b.Id );

            return books.OrderBy ( orderQuery );
        }
    }
}