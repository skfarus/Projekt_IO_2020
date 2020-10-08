using WST.BusinessLogic.Api.Interface;
using WST.BusinessLogic.Communication;
using WST.BusinessLogic.Extensions;
using WST.BusinessLogic.ModelDTO;
using WST.BusinessLogic.NHibernate;
using WST.Domain.Domain;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace WST.BusinessLogic.Api
{
    public class WSTApi : BaseApi, IWSTApi
    {
        public ServiceResponse AddRezerwacje(RezerwacjeDTO rezerwacje)
        {
            using (var session = NHibernateBase.Session)
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var rezerwacjeAdd = rezerwacje.ToRezerwacje();
                        session.Save(rezerwacjeAdd);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return new ServiceResponse()
                        {
                            Errors = e.StackTrace + " " + e.Message,
                            Success = false
                        };
                    }
                }
            }
            return new ServiceResponse();
        }
        public ServiceResponse AddWypozyczenie(WypozyczeniaDTO Wypozyczenie)
        {
            using (var session = NHibernateBase.Session)
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        int ilosc_wyp = 0;
                        int ilosc_rez = 0;
                        var produkty = session.Query<Produkty>()
                        .Where(y => y.Id == int.Parse(Wypozyczenie.Produkt_id));

                        foreach (var item in produkty)
                        {
                            foreach (var wyp in session.Query<Wypozyczenia>().Where(x => x.Produkt_id == item.Id.ToString()))
                            {
                                ilosc_wyp = ilosc_wyp + int.Parse(wyp.Ilosc);
                            }
                            foreach (var wyp in session.Query<Rezerwacje>()
                                .Where(x => x.Produkt_id == item.Id.ToString() && x.Uzytkownik_id != Wypozyczenie.Uzytkownik_id))
                            {
                                ilosc_rez = ilosc_rez + int.Parse(wyp.Ilosc);
                            }
                            if ((int.Parse(item.Ilosc) - (ilosc_wyp + ilosc_rez)) < int.Parse(Wypozyczenie.Ilosc))
                            {
                                throw new Exception("Niewystarczająca ilość produktu.");
                            }
                        }

                        session.Flush();
                        var WypozyczenieAdd = Wypozyczenie.ToWypozyczenia();
                        session.Save(WypozyczenieAdd);
                        transaction.Commit();
                        session.Flush();

                        var query = string.Format("delete {0} where Produkt_id = :Produkt_id and Uzytkownik_id = :Uzytkownik_id", typeof(Rezerwacje));

                        session.CreateQuery(query)
                            .SetParameter("Produkt_id", Wypozyczenie.Produkt_id)
                            .SetParameter("Uzytkownik_id", Wypozyczenie.Uzytkownik_id)
                            .ExecuteUpdate();

                        session.Flush();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return new ServiceResponse()
                        {
                            Errors = e.StackTrace + " " + e.Message,
                            Success = false
                        };
                    }
                }
            }
            return new ServiceResponse();
        }
        public ServiceResponse AddProdukt(ProduktyDTO produkt)
        {
            using (var session = NHibernateBase.Session)
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var produktAdd = produkt.ToProdukty();
                        session.Save(produktAdd);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return new ServiceResponse()
                        {
                            Errors = e.StackTrace + " " + e.Message,
                            Success = false
                        };
                    }
                }
            }
            return new ServiceResponse();
        }
        public ProduktyServiceResponse GetProdukty()
        {
            try
            {
                using (var session = NHibernateBase.Session)
                {
                    var produkty = session.Query<Produkty>()
                        .Select(x =>
                        new ProduktyDTO()
                        {
                            Id = x.Id,
                            Marka = x.Marka,
                            Model = x.Model,
                            Opis = x.Opis,
                            Ilosc = x.Ilosc,
                        }).ToList();

                    foreach(var produkt in produkty)
                    {
                        int ilosc_wyp = 0;
                        foreach (var wyp in session.Query<Wypozyczenia>().Where(x => x.Produkt_id == produkt.Id.ToString()))
                        {
                            ilosc_wyp = ilosc_wyp + int.Parse(wyp.Ilosc);
                        }
                        int ilosc_rez = 0;
                        foreach (var wyp in session.Query<Rezerwacje>().Where(x => x.Produkt_id == produkt.Id.ToString()))
                        {
                            ilosc_rez = ilosc_rez + int.Parse(wyp.Ilosc);
                        }
                        produkt.Ilosc = "(" + (int.Parse(produkt.Ilosc) - (ilosc_wyp + ilosc_rez)).ToString() + " / " + produkt.Ilosc + ")";
                    }

                    session.Flush();

                    return new ProduktyServiceResponse()
                    {
                        Data = produkty
                    };
                }
            }
            catch (Exception e)
            {
                return new ProduktyServiceResponse()
                {
                    Errors = e.StackTrace + " " + e.Message,
                    Success = false
                };
            }
        }
        public WypozyczeniaServiceResponse GetWypozyczeniaUzytkownika(string uzy_id)
        {
            try
            {
                using (var session = NHibernateBase.Session)
                {
                    var Wypozyczenia = session.Query<Wypozyczenia>()
                        .Where(y=>y.Uzytkownik_id==uzy_id)
                        .Select(x =>
                        new WypozyczeniaDTO()
                        {
                            Id = x.Id,
                            Produkt_id = x.Produkt_id,
                            Uzytkownik_id = x.Uzytkownik_id,
                            Ilosc = x.Ilosc,
                            Data_od = x.Data_od,
                            Ilosc_dni = x.Ilosc_dni,
                            Data_do = x.Data_do
                        }).ToList();

                    session.Flush();

                    return new WypozyczeniaServiceResponse()
                    {
                        Data = Wypozyczenia
                    };
                }
            }
            catch (Exception e)
            {
                return new WypozyczeniaServiceResponse()
                {
                    Errors = e.StackTrace + " " + e.Message,
                    Success = false
                };
            }
        }
        public WypozyczeniaServiceResponse GetWypozyczenia()
        {
            try
            {
                using (var session = NHibernateBase.Session)
                {
                    var Wypozyczenia = session.Query<Wypozyczenia>()
                        .Select(x =>
                        new WypozyczeniaDTO()
                        {
                            Id = x.Id,
                            Produkt_id = x.Produkt_id,
                            Uzytkownik_id = x.Uzytkownik_id,
                            Ilosc = x.Ilosc,
                            Data_od = x.Data_od,
                            Ilosc_dni = x.Ilosc_dni,
                            Data_do = x.Data_do
                        }).ToList();

                    session.Flush();

                    return new WypozyczeniaServiceResponse()
                    {
                        Data = Wypozyczenia
                    };
                }
            }
            catch (Exception e)
            {
                return new WypozyczeniaServiceResponse()
                {
                    Errors = e.StackTrace + " " + e.Message,
                    Success = false
                };
            }
        }
        public RezerwacjeServiceResponse GetRezerwacje(int p_Uzytkonik_id)
        {
            try
            {
                using (var session = NHibernateBase.Session)
                {
                    var rezerwacje = session.Query<Rezerwacje>().Where(y=>y.Uzytkownik_id== p_Uzytkonik_id.ToString())
                        .Select(x =>
                        new RezerwacjeDTO()
                        {
                            Id = x.Id,
                            Produkt_id = x.Produkt_id,
                            Uzytkownik_id = x.Uzytkownik_id,
                            Ilosc = x.Ilosc,
                            Data_od = x.Data_od,
                            Ilosc_dni = x.Ilosc_dni,
                        }).ToList();

                    session.Flush();

                    return new RezerwacjeServiceResponse()
                    {
                        Data = rezerwacje
                    };
                }
            }
            catch (Exception e)
            {
                return new RezerwacjeServiceResponse()
                {
                    Errors = e.StackTrace + " " + e.Message,
                    Success = false
                };
            }
        }
        public UzytkownicyServiceResponse GetUzytkownicy()
        {
            try
            {
                using (var session = NHibernateBase.Session)
                {
                    var uzytkownicy = session.Query<Uzytkownicy>()
                        .Select(x =>
                        new UzytkownicyDTO()
                        {
                            Id = x.Id,
                            Imie = x.Imie,
                            Nazwisko = x.Nazwisko,
                            Email = x.Email,
                            Haslo = x.Haslo,
                            Adres = x.Adres,
                            Telefon = x.Telefon,
                            Admin = x.Admin
                        }).ToList();

                    session.Flush();

                    return new UzytkownicyServiceResponse()
                    {
                        Data = uzytkownicy
                    };
                }
            }
            catch (Exception e)
            {
                return new UzytkownicyServiceResponse()
                {
                    Errors = e.StackTrace + " " + e.Message,
                    Success = false
                };
            }
        }
        public RezerwacjeServiceResponse DelRezerwacje(int id)
        {
            try
            {
                using (var session = NHibernateBase.Session)
                {
                    var query = string.Format("delete {0} where id = :id", typeof(Rezerwacje));

                    session.CreateQuery(query).SetParameter("id", id).ExecuteUpdate();

                    session.Flush();

                    return new RezerwacjeServiceResponse()
                    {
                        Errors = "",
                        Success = true
                    };
                }
            }
            catch (Exception e)
            {
                return new RezerwacjeServiceResponse()
                {
                    Errors = e.StackTrace + " " + e.Message,
                    Success = false
                };
            }
        }
        public WypozyczeniaServiceResponse ZakWypozyczenie(int id)
        {
            try
            {
                using (var session = NHibernateBase.Session)
                {
                    var query = string.Format("Update {0} set Data_do=:date where id = :id", typeof(Wypozyczenia));

                    session.CreateQuery(query).SetParameter("id", id).SetDateTime("date",DateTime.Now).ExecuteUpdate();

                    session.Flush();

                    return new WypozyczeniaServiceResponse()
                    {
                        Errors = "",
                        Success = true
                    };
                }
            }
            catch (Exception e)
            {
                return new WypozyczeniaServiceResponse()
                {
                    Errors = e.StackTrace + " " + e.Message,
                    Success = false
                };
            }
        }
        public ProduktyServiceResponse DelProdukty(int id)
        {
            try
            {
                using (var session = NHibernateBase.Session)
                {
                    var query = string.Format("delete {0} where id = :id", typeof(Produkty));

                    session.CreateQuery(query).SetParameter("id", id).ExecuteUpdate();

                    session.Flush();

                    return new ProduktyServiceResponse()
                    {
                        Errors = "",
                        Success = true
                    };
                }
            }
            catch (Exception e)
            {
                return new ProduktyServiceResponse()
                {
                    Errors = e.StackTrace + " " + e.Message,
                    Success = false
                };
            }
        }
        public UzytkownicyServiceResponse DelUzytkownicy(int id)
        {
            try
            {
                using (var session = NHibernateBase.Session)
                {
                    var query = string.Format("delete {0} where id = :id", typeof(Uzytkownicy));

                    session.CreateQuery(query).SetParameter("id", id).ExecuteUpdate();

                    session.Flush();

                    return new UzytkownicyServiceResponse()
                    {
                        Errors = "",
                        Success = true
                    };
                }
            }
            catch (Exception e)
            {
                return new UzytkownicyServiceResponse()
                {
                    Errors = e.StackTrace + " " + e.Message,
                    Success = false
                };
            }
        }
        public UzytkownicyServiceResponse GetUzytkownik(LogowanieDTO logowanieDTO)
        {
            try
            {
                using (var session = NHibernateBase.Session)
                {
                    var logowanie = session.Query<Uzytkownicy>().Where(x => x.Email == logowanieDTO.Email && x.Haslo == logowanieDTO.Haslo)
                        .Select(x =>
                        new UzytkownicyDTO()
                        {
                            Id = x.Id,
                            Email = x.Email,
                            Haslo = x.Haslo,
                            Imie = x.Imie,
                            Nazwisko = x.Nazwisko,
                            Adres = x.Adres,
                            Telefon = x.Telefon,
                            Admin = x.Admin
                        }).ToList();

                    session.Flush();

                    if (logowanie.Count > 0)
                    {
                        return new UzytkownicyServiceResponse()
                        {
                            Data = logowanie
                        };
                    }
                    else
                    {
                        return new UzytkownicyServiceResponse()
                        {
                            Errors = "Niepoprawne dane logowania.",
                            Success = false
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return new UzytkownicyServiceResponse()
                {
                    Errors = e.StackTrace + " " + e.Message,
                    Success = false
                };
            }
        }
        public UzytkownicyServiceResponse Rejestracja(UzytkownicyDTO rejestracjaDTO)
        {
            int NextId = 0;
            try
            {
                using (var session = NHibernateBase.Session)
                {
                    NextId = session.Query<Uzytkownicy>().Max(t => t.Id) + 1;
                }

                using (var session = NHibernateBase.Session)
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        try
                        {
                            var uzytkownik = new Uzytkownicy();
                            uzytkownik.Id = NextId;
                            uzytkownik.Imie = rejestracjaDTO.Imie;
                            uzytkownik.Nazwisko = rejestracjaDTO.Nazwisko;
                            uzytkownik.Haslo = rejestracjaDTO.Haslo;
                            uzytkownik.Email = rejestracjaDTO.Email;
                            uzytkownik.Adres = rejestracjaDTO.Adres;
                            uzytkownik.Telefon = rejestracjaDTO.Telefon;
                            uzytkownik.Admin = "Nie";

                            session.Save(uzytkownik);
                            transaction.Commit();

                            UzytkownicyDTO uzytkownikDTO = new UzytkownicyDTO();
                            uzytkownikDTO.Id = NextId;
                            uzytkownikDTO.Imie = rejestracjaDTO.Imie;
                            uzytkownikDTO.Nazwisko = rejestracjaDTO.Nazwisko;
                            uzytkownikDTO.Haslo = rejestracjaDTO.Haslo;
                            uzytkownikDTO.Email = rejestracjaDTO.Email;
                            uzytkownikDTO.Adres = rejestracjaDTO.Adres;
                            uzytkownikDTO.Telefon = rejestracjaDTO.Telefon;
                            uzytkownikDTO.Admin = "Nie";

                            List<UzytkownicyDTO> uzytkownikDTOs = new List<UzytkownicyDTO>
                            {
                                uzytkownikDTO
                            };

                            return new UzytkownicyServiceResponse()
                            {
                                Data = uzytkownikDTOs
                            };
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            return new UzytkownicyServiceResponse()
                            {
                                Errors = e.StackTrace + " " + e.Message,
                                Success = false
                            };
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return new UzytkownicyServiceResponse()
                {
                    Errors = e.StackTrace + " " + e.Message,
                    Success = false
                };
            }
        }
        /*
        public ServiceResponse Rejestracja(UzytkownicyDTO uzytkownicy)
        {
            using (var session = NHibernateBase.Session)
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Flush();

                        uzytkownicy.Admin = "NIE";
                        uzytkownicy.Id = 3;
                        var uzytkownicyAdd = uzytkownicy.ToUzytkownicy();
                        session.Save(uzytkownicyAdd);
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return new ServiceResponse()
                        {
                            Errors = e.StackTrace + " " + e.Message,
                            Success = false
                        };
                    }
                }
            }
            return new ServiceResponse();
        }*/
    }
}
