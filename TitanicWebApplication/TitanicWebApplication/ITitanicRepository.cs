namespace TitanicWebApplication
{
	interface ITitanicRepository
	{
		TitanicPassenger[] GetPassengers();
		TitanicPassenger[] Find(string query);
	}
}
