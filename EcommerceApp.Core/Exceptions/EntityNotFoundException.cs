namespace EcommerceApp.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private readonly string defaultMessage;

        public override string Message => defaultMessage;

        public EntityNotFoundException() : this("Entity not found!")
        {
        }

        public EntityNotFoundException(string message)
        {
            defaultMessage = message;
        }
    }
}