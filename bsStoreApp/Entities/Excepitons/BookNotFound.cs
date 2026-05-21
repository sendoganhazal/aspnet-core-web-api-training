namespace Entities.Excepitons
{
    public sealed class BookNotFound : NotFound
    {
        public BookNotFound ( int id ) : base ( $"The book with id {id} does not exist in the database." )
        {
        }
    }

}
