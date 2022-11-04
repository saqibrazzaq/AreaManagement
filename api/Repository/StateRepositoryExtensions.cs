using api.Dtos;
using api.Entities;
using api.Utility.Paging;
using System.Linq.Dynamic.Core;

namespace api.Repository
{
    public static class StateRepositoryExtensions
    {
        public static IQueryable<State> Search(this IQueryable<State> items,
            StateReqSearch searchParams)
        {
            var itemsToReturn = items
                //.Include(x => x.Variants)
                .AsQueryable();

            if (searchParams.CountryId > 0)
            {
                itemsToReturn = itemsToReturn.Where(
                    x => x.CountryId == searchParams.CountryId);
            }

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

        public static IQueryable<State> Sort(this IQueryable<State> items,
            string? orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
                return items.OrderBy(e => e.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<State>(orderBy);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return items.OrderBy(e => e.Name);

            return items.OrderBy(orderQuery);
        }

        public static IQueryable<StateResWithCitiesCount> SearchStatesWithCitiesCount(this IQueryable<StateResWithCitiesCount> items,
            StateReqSearch searchParams)
        {
            var itemsToReturn = items
                //.Include(x => x.Variants)
                .AsQueryable();

            if (searchParams.CountryId > 0)
            {
                itemsToReturn = itemsToReturn.Where(
                    x => x.CountryId == searchParams.CountryId);
            }

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

        public static IQueryable<StateResWithCitiesCount> SortStatesWithCitiesCount(this IQueryable<StateResWithCitiesCount> items,
            string? orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
                return items.OrderBy(e => e.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<StateResWithCitiesCount>(orderBy);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return items.OrderBy(e => e.Name);

            return items.OrderBy(orderQuery);
        }
    }
}
