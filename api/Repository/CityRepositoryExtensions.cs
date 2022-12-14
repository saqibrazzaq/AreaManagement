using api.Dtos;
using api.Entities;
using api.Utility.Paging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace api.Repository
{
    public static class CityRepositoryExtensions
    {
        public static IQueryable<City> Search(this IQueryable<City> items,
            CityReqSearch searchParams)
        {
            var itemsToReturn = items
                .Include(x => x.State.Country)
                .AsQueryable();

            if (searchParams.StateId > 0)
            {
                itemsToReturn = itemsToReturn.Where(
                    x => x.StateId == searchParams.StateId);
            }

            if (string.IsNullOrWhiteSpace(searchParams.SearchText) == false)
            {
                string searchText = searchParams.SearchText.ToLower();
                itemsToReturn = itemsToReturn.Where(
                    x => (x.Name ?? "").Contains(searchParams.SearchText)
                );
            }

            return itemsToReturn;
        }

        public static IQueryable<City> Sort(this IQueryable<City> items,
            string? orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
                return items.OrderBy(e => e.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<City>(orderBy);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return items.OrderBy(e => e.Name);

            return items.OrderBy(orderQuery);
        }

        public static IQueryable<CityResWithAreasCount> SearchCitiesWithAreaCount(
            this IQueryable<CityResWithAreasCount> items,
            CityReqSearch searchParams)
        {
            var itemsToReturn = items
                //.Include(x => x.Variants)
                .AsQueryable();

            if (searchParams.StateId > 0)
            {
                itemsToReturn = itemsToReturn.Where(
                    x => x.StateId == searchParams.StateId);
            }

            if (string.IsNullOrWhiteSpace(searchParams.SearchText) == false)
            {
                string searchText = searchParams.SearchText.ToLower();
                itemsToReturn = itemsToReturn.Where(
                    x => (x.Name ?? "").Contains(searchParams.SearchText)
                );
            }

            return itemsToReturn;
        }

        public static IQueryable<CityResWithAreasCount> SortCitiesWithAreaCount(
            this IQueryable<CityResWithAreasCount> items,
            string? orderBy)
        {
            if (string.IsNullOrWhiteSpace(orderBy))
                return items.OrderBy(e => e.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<CityResWithAreasCount>(orderBy);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return items.OrderBy(e => e.Name);

            return items.OrderBy(orderQuery);
        }
    }
}
