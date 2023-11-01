using Ardalis.Specification;
using Entities;

namespace Application.Specifications
{
    public class BoardLatestVersionSpecification : Specification<Board>
    {
        public BoardLatestVersionSpecification(string boardName)
        {
            Query
                .Where(x => x.Name == boardName)
                .OrderByDescending(x => x.Version);
        }
    }
}
