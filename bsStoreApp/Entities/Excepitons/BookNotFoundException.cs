namespace Entities.Excepitons
{
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException ( int id ) : base ( $"The book with id {id} does not exist in the database." )
        {
        }


    }

}
