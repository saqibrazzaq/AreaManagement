namespace api.Repository
{
    public interface IRepositoryManager
    {
        ICountryRepository CountryRepository { get; }
        IStateRepository StateRepository { get; }
        ICityRepository CityRepository { get; }
        IAreaRepository AreaRepository { get; }
        void Save();
    }
}
