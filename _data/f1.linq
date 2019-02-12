<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var circuits = new Formula1Circuit[] {
		new Formula1Circuit { Name = "А1-Ринг", Country = "Австрия", Current = true, Seasons = "1997–2003, 2014–2018", Length = 4326 },
		new Formula1Circuit { Name = "Аделаида", Country = "Австралия", Current = false, Seasons = "1985–1995", Length = 3780 },
		new Formula1Circuit { Name = "Айн-Диаб", Country = "Марокко", Current = false, Seasons = "1958", Length = 7618 },
		new Formula1Circuit { Name = "Эйнтри", Country = "Великобритания", Current = false, Seasons = "1955, 1957, 1959, 1961–1962", Length = 4828 },
		new Formula1Circuit { Name = "Альберт-Парк", Country = "Австралия", Current = true, Seasons = "1996–2018", Length = 5303 },
		new Formula1Circuit { Name = "Америк", Country = "США", Current = true, Seasons = "2012–2017", Length = 5513 },
		new Formula1Circuit { Name = "АФУС", Country = "Германия", Current = false, Seasons = "1959", Length = 8302 },
		new Formula1Circuit { Name = "Баку", Country = "Азербайджан", Current = true, Seasons = "2016–2018", Length = 6003 },
		new Formula1Circuit { Name = "Сахир", Country = "Бахрейн", Current = true, Seasons = "2004–2010, 2012–2018", Length = 5406 },
		new Formula1Circuit { Name = "Боавишта", Country = "Португалия", Current = false, Seasons = "1958, 1960", Length = 7407 },
		new Formula1Circuit { Name = "Брэндс-Хэтч", Country = "Великобритания", Current = false, Seasons = "1964, 1966, 1968, 1970, 1972, 1974, 1976, 1978, 1980, 1982–1986", Length = 3703 },
		new Formula1Circuit { Name = "Бремгартен", Country = "Швейцария", Current = false, Seasons = "1950–1954", Length = 7280 },
		new Formula1Circuit { Name = "Бугатти", Country = "Франция", Current = false, Seasons = "1967", Length = 4442 },
		new Formula1Circuit { Name = "Цезарь Палас", Country = "США", Current = false, Seasons = "1981–1982", Length = 3650 },
		new Formula1Circuit { Name = "Каталунья", Country = "Испания", Current = true, Seasons = "1991–2018", Length = 4655 },
		new Formula1Circuit { Name = "Клермон-Ферран", Country = "Франция", Current = false, Seasons = "1965, 1969–1970, 1972", Length = 8055 },
		new Formula1Circuit { Name = "Детройт", Country = "США", Current = false, Seasons = "1982–1988", Length = 40234 },
		new Formula1Circuit { Name = "Дижон", Country = "Франция", Current = false, Seasons = "1974, 1977, 1979, 1981–1982, 1984", Length = 3800 },
		new Formula1Circuit { Name = "Донингтон", Country = "Великобритания", Current = false, Seasons = "1993", Length = 4023 },
		new Formula1Circuit { Name = "Имола", Country = "Италия", Current = false, Seasons = "1980–2006", Length = 4933 },
		new Formula1Circuit { Name = "Эшторил", Country = "Португалия", Current = false, Seasons = "1984–1996", Length = 4360 },
		new Formula1Circuit { Name = "Фэйр-Парк", Country = "США", Current = false, Seasons = "1984", Length = 3901 },
		new Formula1Circuit { Name = "Фудзи", Country = "Япония", Current = false, Seasons = "1976–1977, 2007–2008", Length = 4563 },
		new Formula1Circuit { Name = "Автодром Жиля Вильнёва", Country = "Канада", Current = true, Seasons = "1978–1986, 1988–2008, 2010–2018", Length = 4361 },
		new Formula1Circuit { Name = "Мехико-Сити", Country = "Мексика", Current = true, Seasons = "1963–1970, 1986–1992, 2015—2017", Length = 4421 },
		new Formula1Circuit { Name = "Хокенхаймринг", Country = "Германия", Current = true, Seasons = "1970, 1977–1984, 1986–2006, 2008, 2010, 2012, 2014, 2016, 2018", Length = 4574 },
		new Formula1Circuit { Name = "Хунгароринг", Country = "Венгрия", Current = true, Seasons = "1986–2018", Length = 4381 },
		new Formula1Circuit { Name = "Индианаполис Мотор Спидвей", Country = "США", Current = false, Seasons = "1950–19602000–2007", Length = 4192 },
		new Formula1Circuit { Name = "Истанбул Парк", Country = "Турция", Current = false, Seasons = "2005–2011", Length = 5338 },
		new Formula1Circuit { Name = "Жакарепагуа", Country = "Бразилия", Current = false, Seasons = "1978, 1981–1989", Length = 5031 },
		new Formula1Circuit { Name = "Харама", Country = "Испания", Current = false, Seasons = "1968, 1970, 1972, 1974, 1976–1979, 1981", Length = 3312 },
		new Formula1Circuit { Name = "Автодром Джайпи Груп", Country = "Индия", Current = false, Seasons = "2011–2013", Length = 5141 },
		new Formula1Circuit { Name = "Херес", Country = "Испания", Current = false, Seasons = "1986–1990, 1994, 1997", Length = 4428 },
		new Formula1Circuit { Name = "Интерлагос", Country = "Бразилия", Current = true, Seasons = "1973–1977, 1979–1980, 1990–2017", Length = 4309 },
		new Formula1Circuit { Name = "Международный автодром Кореи", Country = "Республика Корея", Current = false, Seasons = "2010–2013", Length = 5615 },
		new Formula1Circuit { Name = "Кьялами", Country = "ЮАР", Current = false, Seasons = "1967–1980, 1982–1985, 1992–1993", Length = 4261 },
		new Formula1Circuit { Name = "Лонг-Бич", Country = "США", Current = false, Seasons = "1976–1983", Length = 3167 },
		new Formula1Circuit { Name = "Маньи-Кур", Country = "Франция", Current = false, Seasons = "1991–2008", Length = 4411 },
		new Formula1Circuit { Name = "Монсанто-Парк", Country = "Португалии", Current = false, Seasons = "1959", Length = 5425 },
		new Formula1Circuit { Name = "Монте-Карло", Country = "Монако", Current = true, Seasons = "1950, 1955–2018", Length = 3337 },
		new Formula1Circuit { Name = "Монжуик-Парк", Country = "Испания", Current = false, Seasons = "1969, 1971, 1973, 1975", Length = 3790 },
		new Formula1Circuit { Name = "Мон-Тремблан", Country = "Канада", Current = false, Seasons = "1968, 1970", Length = 4265 },
		new Formula1Circuit { Name = "Автодром Монца", Country = "Италия", Current = true, Seasons = "1950–1979, 1981–2017", Length = 5793 },
		new Formula1Circuit { Name = "Моспорт-Парк", Country = "Канада", Current = false, Seasons = "1967, 1969, 1971–1977", Length = 3957 },
		new Formula1Circuit { Name = "Нивель-Болер", Country = "Бельгия", Current = false, Seasons = "1972, 1974", Length = 3724 },
		new Formula1Circuit { Name = "Нюрбургринг", Country = "Германия", Current = false, Seasons = "1951–1958, 1961–1969, 1971–1976, 1984–1985, 1995–2007, 2009, 2011, 2013", Length = 5148 },
		new Formula1Circuit { Name = "Буэнос-Айрес", Country = "Аргентина", Current = false, Seasons = "1953–1958, 1960, 1972–1975, 1977–1981, 1995–1998", Length = 4259 },
		new Formula1Circuit { Name = "Остеррайхринг", Country = "Австрия", Current = false, Seasons = "1970–1987", Length = 4326 },
		new Formula1Circuit { Name = "Поль Рикар", Country = "Франция", Current = true, Seasons = "1971, 1973, 1975–1976, 1978, 1980, 1982–1983, 1985–1990, 2018", Length = 5842 },
		new Formula1Circuit { Name = "Педральбес", Country = "Испания", Current = false, Seasons = "1951, 1954", Length = 6316 },
		new Formula1Circuit { Name = "Пескара", Country = "Италия", Current = false, Seasons = "1957", Length = 25579 },
		new Formula1Circuit { Name = "Финикс", Country = "США", Current = false, Seasons = "1989–1991", Length = 3720 },
		new Formula1Circuit { Name = "Ист-Лондон", Country = "Южно-Африканский Союз", Current = false, Seasons = "1962–1963, 1965", Length = 3919 },
		new Formula1Circuit { Name = "Реймс-Гу", Country = "Франция", Current = false, Seasons = "1950–1951, 1953–1954, 1956, 1958–1961, 1963, 1966", Length = 8302 },
		new Formula1Circuit { Name = "Риверсайд", Country = "США", Current = false, Seasons = "1960", Length = 5270 },
		new Formula1Circuit { Name = "Руан", Country = "Франция", Current = false, Seasons = "1952, 1957, 1962, 1964, 1968", Length = 6542 },
		new Formula1Circuit { Name = "Андерсторп", Country = "Швеция", Current = false, Seasons = "1973–1978", Length = 4031 },
		new Formula1Circuit { Name = "Себринг", Country = "США", Current = false, Seasons = "1959", Length = 8356 },
		new Formula1Circuit { Name = "Сепанг", Country = "Малайзия", Current = false, Seasons = "1999–2017", Length = 5543 },
		new Formula1Circuit { Name = "Шанхай", Country = "Китайская Народная Республика", Current = true, Seasons = "2004–2018", Length = 5451 },
		new Formula1Circuit { Name = "Сильверстоун", Country = "Великобритания", Current = true, Seasons = "1950–1954, 1956, 1958, 1960, 1963, 1965, 1967, 1969, 1971, 1973, 1975, 1977, 1979, 1981, 1983, 1985, 1987–2018", Length = 5891 },
		new Formula1Circuit { Name = "Марина Бей", Country = "Сингапур", Current = true, Seasons = "2008–2017", Length = 5065 },
		new Formula1Circuit { Name = "Спа-Франкоршам", Country = "Бельгия", Current = true, Seasons = "1950–1956, 1958, 1960–1968, 1970, 1983, 1985–2002, 2004–2005, 2007–2017", Length = 7004 },
		new Formula1Circuit { Name = "Судзука", Country = "Япония", Current = true, Seasons = "1987–2006, 2009–2017", Length = 5807 },
		new Formula1Circuit { Name = "TI", Country = "Япония", Current = false, Seasons = "1994–1995", Length = 3703 },
		new Formula1Circuit { Name = "Сочи Автодром", Country = "Россия", Current = true, Seasons = "2014–2017", Length = 5848 },
		new Formula1Circuit { Name = "Валенсия", Country = "Испания", Current = false, Seasons = "2008–2012", Length = 5440 },
		new Formula1Circuit { Name = "Уоткинс-Глен", Country = "США", Current = false, Seasons = "1961–1980", Length = 5435 },
		new Formula1Circuit { Name = "Яс Марина", Country = "ОАЭ", Current = true, Seasons = "2009–2017", Length = 5554 },
		new Formula1Circuit { Name = "Зандвоорт", Country = "Нидерланды", Current = false, Seasons = "1952–1953, 1955, 1958–1971, 1973–1985", Length = 4307 },
		new Formula1Circuit { Name = "Цельтвег", Country = "Австрия", Current = false, Seasons = "1964", Length = 3200 },
		new Formula1Circuit { Name = "Зольдер", Country = "Бельгия", Current = false, Seasons = "1973, 1975–1982, 1984", Length = 3977 }
	};
	
	//circuits.Dump();
	//circuits.Where(c => c.Current).Select(c => c.Country).Distinct().OrderBy(_ => _).Dump();
	circuits.Where(c => c.Current).Select(c => c.Length).OrderByDescending(_ => _).Dump();
}

class Formula1Circuit
{
	public string Name { get; set; }
	public string Country { get; set; }
	public bool Current { get; set; }
	public string Seasons { get; set; }
	public int Length { get; set; }
}
