using Ardalis.Specification;

namespace Application.Specifications.Game
{
    internal class GamyByNameSpec : Specification<Domain.Entities.Game>
    {
        public GamyByNameSpec(string name)
        {
            Query.Where(e => e.Name.ToLower() == name.ToLower());
        }
    }
}
