namespace TitanicWebApplication
{
	interface ITitanicRepository
	{
		string[] GetCountries();
		TitanicPassenger[] GetPassengers();
		TitanicPassenger[] Find(string query);
	}
}
