using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie3.Common.Enums;
using Zadanie3.Common.Extensions;
using zadanie3.Data.SQL.DAO;
namespace zadanie3.Data.SQL.Migration
{
    public class DatabaseSeed
    {
        private readonly SklepDbContext _context;
        
        public DatabaseSeed(SklepDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            #region Uzytkownicy

            var userList = BuildUserList();
            _context.User.AddRange(userList);
            _context.SaveChanges();

            #endregion

            #region Autorzy

            var autorzyList = BuildAutorzyList();
            _context.Autorzy.AddRange(autorzyList);
            _context.SaveChanges();

            #endregion

            #region Planszowki

            var planszowkiList = BuildPlanszowkiList();
            _context.Planszowki.AddRange(planszowkiList);
            _context.SaveChanges();

            #endregion

            #region Zamowienia

            var zamowienialist = BuildZamowieniaList(userList);
            _context.Zamowienia.AddRange(zamowienialist);
            _context.SaveChanges();

            #endregion

            #region AutorzyPlanszowek

            var autorzyplanszowekList = BuildAutorzyPlanszowekList(autorzyList,planszowkiList);
            _context.AutorzyPlanszowek.AddRange(autorzyplanszowekList);
            _context.SaveChanges();

            #endregion

            #region ZamowieniaPlanszowek

            var zamowieniaPlanszowekList = BuildZamowieniaPlanszowekList(zamowienialist, planszowkiList);
            _context.ZamowieniaPlanszowek.AddRange(zamowieniaPlanszowekList);
            _context.SaveChanges();

            #endregion
        }

        private IEnumerable<User> BuildUserList()
        {
            var userList = new List<User>();
            var user = new User()
            {
                Username = "rogal",
                Name = "kamil",
                Email = "kamil.rogalinski@gmail.com",
                RegistrationDate = DateTime.Now.AddYears(-3),
                
                BirthDate = new DateTime(1998, 9, 8),
                Gender = Gender.Male
             
            };
            userList.Add(user);

            var user2 = new User()
            {
                Username = "Karol",
                Name = "Nowak",
                Email = "karol.nowak@gmail.com",
                RegistrationDate = DateTime.Now.AddYears(-3),
                BirthDate = new DateTime(1998, 12, 7),
                Gender = Gender.Male
            };
            userList.Add(user2);
            
            for (int i = 3; i <= 10; i++)
            {
                var user3 = new User
                {
                    Username = "user" + i,
                    Name = "Imię",
                    Email = "user" + i + "@gamil.pl",
                    RegistrationDate = DateTime.Now.AddYears(-i).AddDays(-i),
                    BirthDate = DateTime.Now.AddYears(-i*2).AddDays(-i*2),
                    Gender = i % 2 == 0 ? Gender.Female : Gender.Male
                   
                };
                userList.Add(user3);
            }

            return userList;
        }
        
        private IEnumerable<Autorzy> BuildAutorzyList()
        {
            var autorzyList = new List<Autorzy>();
            var autorzy = new Autorzy()
            {
                Imie = "Wojciech",
                Nazwisko = "Zalewski"
            };
            autorzyList.Add(autorzy);

            var autorzy2 = new Autorzy()
            {
                Imie = "Alfred",
                Nazwisko = "Butts"
            };
            autorzyList.Add(autorzy2);

            for (int i = 3; i <= 20; i++)
            {
                var autorzy3 = new Autorzy
                {
                    Imie = "autorzy" + i,
                    Nazwisko = "autorzy" + i
                };
                autorzyList.Add(autorzy3);
            }

            return autorzyList;

        }

        private IEnumerable<Planszowki> BuildPlanszowkiList()
        {
            var planszowkiList = new List<Planszowki>();
            var planszowki = new Planszowki()
            {
                Nazwa = "Catan",
                Typ = "Ekonomiczna",
                IloscGraczy = "2-4",
                Cena = 89,
                CzasGry = "Do 1 godziny",
                Wiek = "od 10 lat",
                Wydanie = "Polskie"
            };
            planszowkiList.Add(planszowki);
            
            var planszowki1 = new Planszowki()
            {
                Nazwa = "Talisman 4rd.",
                Typ = "Strategiczna - RPG",
                IloscGraczy = "2-6",
                Cena = 199,
                CzasGry = "Do 4 godzin",
                Wiek = "od 13 lat",
                Wydanie = "Polskie"
            };
            planszowkiList.Add(planszowki1);
            
            for (int i = 3; i <= 20; i++)
            {
                var planszowki3 = new Planszowki
                {
                    Nazwa = "Planszowka" + i,
                    Typ = "Typ" + i,
                    IloscGraczy = "1-4",
                    Cena = 199 + i,
                    CzasGry = "Do" + i +  "godzin",
                    Wiek = "od" + i + "lat",
                    Wydanie = "Polskie"
                };
                planszowkiList.Add(planszowki3);
            }

            return planszowkiList;
        }

        private IEnumerable<Zamowienia> BuildZamowieniaList(IEnumerable<User> userList)
        {
            var rand = new Random();
            var zamowieniaList = new List<Zamowienia>();
            foreach (var user in userList)
            {
                var User = userList.First(x => x.UserId == user.UserId);
                var range = rand.Next(1, 4);
                for (int i = 0; i < range; i++)
                {
                    zamowieniaList.Add(new Zamowienia
                    {
                        Uzytkownikid = user.UserId,
                        DataZlozeniaZamowienia = DateTime.Now.AddDays(-2)
                    });
                }
            }

            return zamowieniaList;
        }

        private IEnumerable<ZamowieniaPlanszowek> BuildZamowieniaPlanszowekList(IEnumerable<Zamowienia> zamowieniaList,
            IEnumerable<Planszowki> planszowkiList)
        {
            var zamowieniaPlanszowekList = new List<ZamowieniaPlanszowek>();
            zamowieniaList.ToList().Shuffle();
            planszowkiList.ToList().Shuffle();
            var rnd = new Random();
            for (int i = 0; i < zamowieniaList.Count(); i++)
            {
                var index = rnd.Next(0, planszowkiList.Count());
                zamowieniaPlanszowekList.Add(new ZamowieniaPlanszowek
                {
                    Zamowienieid = zamowieniaList.ToList()[i].Zamowienieid,
                    Planszowkaid = planszowkiList.ToList()[index].Planszowkaid
                });
            }
            return zamowieniaPlanszowekList;
        }

        private IEnumerable<AutorzyPlanszowek> BuildAutorzyPlanszowekList(IEnumerable<Autorzy> autorzyList,
            IEnumerable<Planszowki> planszowkiList)
        {
            var autorzyplanszowekList = new List<AutorzyPlanszowek>();
            autorzyList.ToList().Shuffle();
            planszowkiList.ToList().Shuffle();
            var rnd = new Random();
            for (int i = 0; i < autorzyList.Count(); i++)
            {
                var index = rnd.Next(0, autorzyplanszowekList.Count());

                autorzyplanszowekList.Add(new AutorzyPlanszowek
                {
                    Autorid = autorzyList.ToList()[index].Autorid,
                    Planszowkaid = planszowkiList.ToList()[i].Planszowkaid
                });
            }

            return autorzyplanszowekList;
        }
        
        
        
    }
}