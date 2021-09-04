using Ardalis.Specification;
using Entities;
using System.Linq;

namespace Application.Specifications
{
    public class BoardsByNameSpecification : Specification<Board>
    {
        public BoardsByNameSpecification(string boardName)
        {
            Query
                .Where(x => x.Name == boardName)
                .AsNoTracking();
        }
    }
}
