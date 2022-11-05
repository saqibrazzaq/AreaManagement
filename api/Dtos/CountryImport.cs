namespace api.Dtos
{
    public class CountryImport
    {
        public int id { get; set; }
        public string name { get; set; }
        public string iso3 { get; set; }
        public IEnumerable<StateImport> states { get; set; }
    }

    public class StateImport
    {
        public int id { get; set; }
        public string name { get; set; }
        public string state_code { get; set; }
        public IEnumerable<CityImport> cities { get; set; }
    }

    public class CityImport
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
