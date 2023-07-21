using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specifications.Directores
{
    public class DirectorForCountingSpecification : BaseSpecification<Director>
    {
        public DirectorForCountingSpecification( DirectorSpecificationParams directorParams) 
            : base(x => string.IsNullOrEmpty(directorParams.Search) || x.Nombre!.Contains(directorParams.Search))
        {
            
        }
    }
}
