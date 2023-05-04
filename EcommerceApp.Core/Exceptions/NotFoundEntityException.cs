namespace EcommerceApp.Domain.Exceptions
{
    public class NotFoundEntityException : Exception
    {
        private readonly string defaultMessage;

        public override string Message => defaultMessage;

        public NotFoundEntityException() : this("Entity not found!")
        {
        }

        public NotFoundEntityException(string message)
        {
            defaultMessage = message;
        }
    }
}