using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace TitanicWebApplication
{
	public class XmlTitanicRepository : ITitanicRepository
	{
		private string _xmlPath;

		public XmlTitanicRepository(string xmlPath)
		{
			_xmlPath = xmlPath;
		}

		static TitanicPassenger[] _passengers;

		public TitanicPassenger[] GetPassengers()
		{
			if (_passengers == null)
			{
				using (var fstream = File.OpenRead(_xmlPath))
				{
					XmlSerializer s = new XmlSerializer(typeof(TitanicPassenger[]));
					_passengers = (TitanicPassenger[])s.Deserialize(fstream);
				}
			}
			return _passengers;
		}

		public TitanicPassenger[] Find(string query)
		{
			return GetPassengers().Where(pax =>
				(pax.FamilyName ?? "").Contains(query)
				|| (pax.GivenName ?? "").Contains(query)
				|| (pax.JobTitle ?? "").Contains(query)
			).ToArray();
		}
	}
}