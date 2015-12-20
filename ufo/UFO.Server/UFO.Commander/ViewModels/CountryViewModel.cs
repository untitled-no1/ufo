using UFO.Server.Domain;

namespace UFO.Commander.ViewModels
{
    public class CountryViewModel
    {
        private Country country;

        public string Code => country?.Code;

        public string Name => country?.Name;

        public CountryViewModel(Country c)
        {
            country = c;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}