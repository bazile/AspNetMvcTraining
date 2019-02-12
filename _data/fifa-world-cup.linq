<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Text.RegularExpressions</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
    var stats = new Stat[] {
        new Stat { Year = 1930, Hosts = new[] {"Уругвай"}                   , Team1 = "Уругвай"  , Score12 = "4:2", Team2 = "Аргентина"   , Team3="США"       , Score34=""   , Team4="Югославия"  },
        new Stat { Year = 1934, Hosts = new[] {"Италия"}                    , Team1 = "Италия"   , Score12 = "2:1", Team2 = "Чехословакия", Team3="Германия"  , Score34="3:2", Team4="Австрия"    },
        new Stat { Year = 1938, Hosts = new[] {"Франция"}                   , Team1 = "Италия"   , Score12 = "4:2", Team2 = "Венгрия"     , Team3="Бразилия"  , Score34="4:2", Team4="Швеция"     },
        new Stat { Year = 1950, Hosts = new[] {"Бразилия"}                  , Team1 = "Уругвай"  , Score12 = "2:1", Team2 = "Бразилия"    , Team3="Швеция"    , Score34="3:1", Team4="Испания"    },
        new Stat { Year = 1954, Hosts = new[] {"Швейцария"}                 , Team1 = "ФРГ"      , Score12 = "3:2", Team2 = "Венгрия"     , Team3="Австрия"   , Score34="3:1", Team4="Уругвай"    },
        new Stat { Year = 1958, Hosts = new[] {"Швеция"}                    , Team1 = "Бразилия" , Score12 = "5:2", Team2 = "Швеция"      , Team3="Франция"   , Score34="6:3", Team4="ФРГ"        },
        new Stat { Year = 1962, Hosts = new[] {"Чили"}                      , Team1 = "Бразилия" , Score12 = "3:1", Team2 = "Чехословакия", Team3="Чили"      , Score34="1:0", Team4="Югославия"  },
        new Stat { Year = 1966, Hosts = new[] {"Англия"}                    , Team1 = "Англия"   , Score12 = "4:2", Team2 = "ФРГ"         , Team3="Португалия", Score34="2:1", Team4="СССР"       },
        new Stat { Year = 1970, Hosts = new[] {"Мексика"}                   , Team1 = "Бразилия" , Score12 = "4:1", Team2 = "Италия"      , Team3="ФРГ"       , Score34="1:0", Team4="Уругвай"    },
        new Stat { Year = 1974, Hosts = new[] {"ФРГ"}                       , Team1 = "ФРГ"      , Score12 = "2:1", Team2 = "Нидерланды"  , Team3="Польша"    , Score34="1:0", Team4="Бразилия"   },
        new Stat { Year = 1978, Hosts = new[] {"Аргентина"}                 , Team1 = "Аргентина", Score12 = "3:1", Team2 = "Нидерланды"  , Team3="Бразилия"  , Score34="2:1", Team4="Италия"     },
        new Stat { Year = 1982, Hosts = new[] {"Испания"}                   , Team1 = "Италия"   , Score12 = "3:1", Team2 = "ФРГ"         , Team3="Польша"    , Score34="3:2", Team4="Франция"    },
        new Stat { Year = 1986, Hosts = new[] {"Мексика"}                   , Team1 = "Аргентина", Score12 = "3:2", Team2 = "ФРГ"         , Team3="Франция"   , Score34="4:2", Team4="Бельгия"    },
        new Stat { Year = 1990, Hosts = new[] {"Италия"}                    , Team1 = "ФРГ"      , Score12 = "1:0", Team2 = "Аргентина"   , Team3="Италия"    , Score34="2:1", Team4="Англия"     },
        new Stat { Year = 1994, Hosts = new[] {"США"}                       , Team1 = "Бразилия" , Score12 = "3:2", Team2 = "Италия"      , Team3="Швеция"    , Score34="4:0", Team4="Болгария"   },
        new Stat { Year = 1998, Hosts = new[] {"Франция"}                   , Team1 = "Франция"  , Score12 = "3:0", Team2 = "Бразилия"    , Team3="Хорватия"  , Score34="2:1", Team4="Нидерланды" },
        new Stat { Year = 2002, Hosts = new[] {"Республика Корея", "Япония"}, Team1 = "Бразилия" , Score12 = "2:0", Team2 = "Германия"    , Team3="Турция"    , Score34="3:2", Team4="Южная Корея"},
        new Stat { Year = 2006, Hosts = new[] {"Германия"}                  , Team1 = "Италия"   , Score12 = "5:3", Team2 = "Франция"     , Team3="Германия"  , Score34="3:1", Team4="Португалия" },
        new Stat { Year = 2010, Hosts = new[] {"ЮАР"}                       , Team1 = "Испания"  , Score12 = "1:0", Team2 = "Нидерланды"  , Team3="Германия"  , Score34="3:2", Team4="Уругвай"    },
        new Stat { Year = 2014, Hosts = new[] {"Бразилия"}                  , Team1 = "Германия" , Score12 = "1:0", Team2 = "Аргентина"   , Team3="Нидерланды", Score34="3:0", Team4="Бразилия"   },
        new Stat { Year = 2018, Hosts = new[] {"Россия"}                    , Team1 = "Франция"  , Score12 = "4:2", Team2 = "Хорватия"    , Team3="Бельгия"   , Score34="2:0", Team4="Англия"     },
    };
    //stats.Dump();
    stats.GroupBy(s => s.Team1)
        .Select(g => new { Team = g.Key, Wins = g.Count() })
        .OrderByDescending(r => r.Wins)
        .Dump();
}

class Stat
{
    public int Year { get; set; }
    public string[] Hosts { get; set; }
    public string Team1 { get; set; }
    public string Score12 { get; set; }
    public string Team2 { get; set; }
    public string Team3 { get; set; }
    public string Score34 { get; set; }
    public string Team4 { get; set; }
}
