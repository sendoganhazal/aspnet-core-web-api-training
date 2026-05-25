using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Excepitons;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public BookManager ( IRepositoryManager manager, ILoggerService logger, IMapper mapper )
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }


        public Book CreateOneBook ( Book book )
        {

            _manager.Book.CreateOneBook ( book );
            _manager.Save ( );
            return book;
        }

        public void DeleteOneBook ( int id, bool trackChanges )
        {

            // check if the book exists
            var entity = _manager.Book.GetOneBookById ( id, trackChanges );

            if ( entity is null )
            {
                throw new BookNotFoundException ( id ); //404
            }

            _manager.Book.DeleteOneBook ( entity );
            _manager.Save ( );
        }

        public IEnumerable<BookDto> GetAllBooks ( bool trackChanges )
        {
            var books = _manager.Book.GetAllBooks ( trackChanges );
            return _mapper.Map<IEnumerable<BookDto>> ( books );
        }

        public Book GetOneBookById ( int id, bool trackChanges )
        {
            var book = _manager.Book.GetOneBookById ( id, trackChanges );

            if ( book is null )
                throw new BookNotFoundException ( id ); //404
            return book;
        }

        public void UpdateOneBook ( int id, BookDtoForUpdate bookDto, bool trackChanges )
        {
            // check if the book exists
            var entity = _manager.Book.GetOneBookById ( id, trackChanges);

            if ( entity is null )
                throw new BookNotFoundException ( id ); //404


            //Mapping
   
            entity = _mapper.Map<Book> ( bookDto );


            _manager.Book.Update ( entity );
            _manager.Save ( );
        }
    }
}
