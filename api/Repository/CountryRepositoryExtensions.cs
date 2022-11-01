using api.Dtos;
using api.Entities;
using api.Utility.Paging;
using System.Linq.Dynamic.Core;

namespace api.Repository
{
    public static class CountryRepositoryExtensions
    {
        public static IQueryable<Country> Search(this IQueryable<Country> items,
            CountryReqSearch searchParams)
        {
            var itemsToReturn = items
                //.Include(x => x.Variants)
                .AsQueryable();

            if (string.IsNullOrWhiteSpace(searchParams.SearchText) == false)
            {
                string searchText = searchParams.SearchText.ToLower();
                itemsToReturn = itemsToReturn.Where(
                    x => (x.Name ?? "").Contains(searchParams.SearchText) ||
                    (x.Code ?? "").Contains(searchParams.SearchText)
                );
            }

            return itemsToReturn;
        }

        public static IQueryable<Country> Sort(this IQueryable<Country> items,
            string? orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
                return items.OrderBy(e => e.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Country>(orderBy);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return items.OrderBy(e => e.Name);

            return items.OrderBy(orderQuery);
        }
    }
}
