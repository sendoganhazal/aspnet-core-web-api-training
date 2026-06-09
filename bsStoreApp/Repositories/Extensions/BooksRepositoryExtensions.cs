using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}