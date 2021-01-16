using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQueryable(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria); // p => p.ProductTypeId == id
            }

            if (specification.OrderBy != null)
            {
                query.OrderBy(specification.OrderBy);
            }
            if (specification.OrderByDescending != null)
            {
                query.OrderByDescending(specification.OrderByDescending);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}