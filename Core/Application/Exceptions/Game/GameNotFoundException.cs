using Application.Exceptions.Common;

namespace Application.Exceptions.Game
{
    public class GameNotFoundException : ApiException
    {
        public GameNotFoundException() : base("Game is not found")
        {
        }
    }
}
