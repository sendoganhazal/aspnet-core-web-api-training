namespace Entities.Excepitons
{
    public abstract class NotFound : Exception
    {
        protected NotFound ( string message ) : base ( message )
        {
        }
    }

}
