namespace Application.Exceptions
{
    public class GameNotFoundException : Exception
    {
        public GameNotFoundException() : base("Game is not found")
        {
        }
    }
}
