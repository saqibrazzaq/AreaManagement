﻿using api.Data;
using api.Dtos;
using api.Entities;
using api.Exceptions;
using api.Utility.Paging;
using System.Linq;

namespace api.Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CountryRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public PagedList<Country> SearchCountries(CountryReqSearch dto, bool trackChanges)
        {
            var entities = FindAll(trackChanges)
                .Search(dto)
                .Sort(dto.OrderBy)
                .Skip((dto.PageNumber - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .ToList();
            var count = FindAll(trackChanges)
                .Search(dto)
                .Count();
            return new PagedList<Country>(entities, count,
                dto.PageNumber, dto.PageSize);
        }
        public PagedList<CountryResWithStatesCount> SearchCountriesWithStatesCount(CountryReqSearch dto, bool trackChanges)
        {
            var entities = GetCustomQueryWithStatesCount()
                .SearchWithStatesCount(dto)
                .SortWithStatesCount(dto.OrderBy)
                .Skip((dto.PageNumber - 1) * dto.PageSize)
                .Take(dto.PageSize)
                .ToList();
            var count = GetCustomQueryWithStatesCount()
                .SearchWithStatesCount(dto)
                .Count();
            return new PagedList<CountryResWithStatesCount>(entities, count,
                dto.PageNumber, dto.PageSize);
        }

        private IQueryable<CountryResWithStatesCount> GetCustomQueryWithStatesCount()
        {
            var query = (
                from c in _appDbContext.Countries
                join s in _appDbContext.Sates on c.CountryId equals s.CountryId into grouping
                from p in grouping.DefaultIfEmpty()
                group p by new { c.CountryId, c.Code, c.Name } into g
                select new CountryResWithStatesCount()
                {
                    CountryId = g.Key.CountryId,
                    Code = g.Key.Code,
                    Name = g.Key.Name,
                    StatesCount = g.Count(x => x != null)
                }
                        );
            return query;
        }

        public CountryResWithStatesCount GetCountryWithStatesCount(int countryId)
        {
            var query = (
                from c in _appDbContext.Countries
                join s in _appDbContext.Sates on c.CountryId equals s.CountryId
                group s by new { c.CountryId, c.Code, c.Name } into g
                select new CountryResWithStatesCount()
                {
                    CountryId = g.Key.CountryId,
                    Code = g.Key.Code,
                    Name = g.Key.Name,
                    StatesCount = g.Count()
                }
                        ).FirstOrDefault();

            return query;
        }
    }
}
