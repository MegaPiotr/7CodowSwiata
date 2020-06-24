using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using SevenWondersCommon;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using _7CodowSwiata.Converter;
using System.Linq;

namespace _7CodowSwiata.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        #region Kod automatycznie wygenerowany


        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        #endregion

        private Comparison<Karta> Comparer = (v1, v2) =>
        {
            if (v1.Kolor < v2.Kolor)
                return -1;
            else if (v1.Kolor > v2.Kolor)
                return 1;
            else
                return string.Compare(v1.Nazwa, v2.Nazwa, StringComparison.Ordinal);
        };

        public ICommand BeforeDragKartaCommand => new RelayCommand<Karta>(BeforeDragKarta);

        private void BeforeDragKarta(Karta karta)
        {
            TymczasowoWybranaKarta = karta;
        }

        public ICommand AfterDragKartaCommand => new RelayCommand<bool>(AfterDragKarta);

        private void AfterDragKarta(bool rezultat)
        {
            if(!rezultat)
                TymczasowoWybranaKarta = null;
        }

        public ICommand DropKartaCommand => new RelayCommand<TypRuchu>(DropKarta);

        private void DropKarta(TypRuchu typ)
        {
            if (AktualnieWybranaKarta != null)
                Karty.Add(AktualnieWybranaKarta, Comparer);
            Karty.Remove(TymczasowoWybranaKarta);
            AktualnieWybranaKarta = TymczasowoWybranaKarta;
            TymczasowoWybranaKarta = null;
            TypRuchu = typ;
            Ruch ruch = new Ruch(Gracz, AktualnieWybranaKarta, TypRuchu.Value);
            Gra.WykonajRuch(ruch);
        }

        public ICommand BeforeDragListaCommand => new RelayCommand<Karta>(BeforeDragLista);

        private void BeforeDragLista(Karta karta)
        {
            TymczasowoWybranaKarta = karta;
            Karty.Remove(karta);
        }

        public ICommand AfterDragListaCommand => new RelayCommand<bool>(AfterDragLista);

        private void AfterDragLista(bool rezultat)
        {
            if (!rezultat)
            {
                Karty.Add(TymczasowoWybranaKarta, Comparer);
                TymczasowoWybranaKarta = null;
            }
        }

        public ICommand DropListaCommand => new RelayCommand(DropLista);

        private void DropLista()
        {
            Karty.Add(TymczasowoWybranaKarta, Comparer);
            AktualnieWybranaKarta = null;
            TymczasowoWybranaKarta = null;
            TypRuchu = null;
            //todo obadać
            //Gra.CofnijRuch();
        }

        public ObservableCollection<Karta> Karty { get; set; }
        public ObservableCollection<Karta> KartyNaKtoreStac { get; set; }

        //zaznaczona na liście
        private Karta _ZaznaczonaKarta;
        public Karta ZaznaczonaKarta
        {
            get => _ZaznaczonaKarta;
            set
            {
                _ZaznaczonaKarta = value;
                RaisePropertyChanged();
            }
        }
        //przeciągana
        public Gracz Gracz { get; set; }
        public Gra Gra { get; set; } //= new Gra();//todo jakoś rozpocząć grę
        public ObservableCollection<Gracz> Gracze { get; set; }

        private Karta _AktualnieWybranaKarta;
        public Karta AktualnieWybranaKarta
        {
            get => _AktualnieWybranaKarta;
            set
            {
                _AktualnieWybranaKarta = value;
                RaisePropertyChanged();
            }
        }

        public Karta TymczasowoWybranaKarta { get; set; }

        private TypRuchu? _TypRuchu;
        public TypRuchu? TypRuchu
        {
            get => _TypRuchu;
            set
            {
                _TypRuchu = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(/*IDataService dataService*/)
        {
            var cegielnia = new Karta()
            {
                Efekty = new List<Efekt>(){new Efekt(TypEfektu.Produkcja, Dzialanie.DodajCegle, 1)},
                Koszt = new List<Surowiec>(){new Surowiec(RodzajSurowca.Moneta, 1)},
                Nazwa = "Cegielnia",
                Obrazek = (ImageSource)Application.Current.Resources["cegielnia"],
                Kolor = KolorKarty.Brazowa
            };
            var karawana = new Karta()
            {
                Efekty = new List<Efekt>(){new Efekt(TypEfektu.Produkcja, Dzialanie.DodajDrewnoKamienZlotoLubCegle, 1)},
                Koszt = new List<Surowiec>(){new Surowiec(RodzajSurowca.Drewno, 2)},
                Nazwa = "Karawana",
                Obrazek = (ImageSource)Application.Current.Resources["karawana"],
                Kolor = KolorKarty.Zolta
            };
            var laboratorium = new Karta()
            {
                Efekty = new List<Efekt>() { new Efekt(TypEfektu.LiczeniePunktow, Dzialanie.DodajDrewnoKamienZlotoLubCegle, 1) },
                Koszt = new List<Surowiec>() { new Surowiec(RodzajSurowca.Cegla, 2), new Surowiec(RodzajSurowca.Papier, 1) },
                Nazwa = "Laboratorium",
                Obrazek = (ImageSource)Application.Current.Resources["laboratorium"],
                Kolor = KolorKarty.Zielona
            };
            var odlewnia = new Karta()
            {
                Efekty = new List<Efekt>() { new Efekt(TypEfektu.Produkcja, Dzialanie.DodajZloto, 2) },
                Koszt = new List<Surowiec>() { new Surowiec(RodzajSurowca.Moneta, 1) },
                Nazwa = "Odlewnia",
                Obrazek = (ImageSource)Application.Current.Resources["odlewnia"],
                Kolor = KolorKarty.Brazowa
            };
            var sad = new Karta()
            {
                Efekty = new List<Efekt>() { new Efekt(TypEfektu.LiczeniePunktow, Dzialanie.DodajPunkty, 4) },
                Koszt = new List<Surowiec>() { new Surowiec(RodzajSurowca.Cegla, 1), new Surowiec(RodzajSurowca.Tkanina, 1) },
                Nazwa = "Sąd",
                Obrazek = (ImageSource)Application.Current.Resources["sad"],
                Kolor = KolorKarty.Niebieska
            };
            var stajnie = new Karta()
            {
                Efekty = new List<Efekt>() { new Efekt(TypEfektu.Pojedynek, Dzialanie.DodajPunktyWojny, 2) },
                Koszt = new List<Surowiec>() { new Surowiec(RodzajSurowca.Cegla, 1), new Surowiec(RodzajSurowca.Drewno, 1), new Surowiec(RodzajSurowca.Zloto, 1) },
                Nazwa = "Stajnie",
                Obrazek = (ImageSource)Application.Current.Resources["stajnie"],
                Kolor = KolorKarty.Czerwona
            };
            var warsztattkacki = new Karta()
            {
                Efekty = new List<Efekt>() { new Efekt(TypEfektu.Produkcja, Dzialanie.DodajTkanine, 1) },
                Koszt = new List<Surowiec>(),
                Nazwa = "Warsztat tkacki",
                Obrazek = (ImageSource)Application.Current.Resources["warsztattkacki"],
                Kolor = KolorKarty.Szara
            };
            Gracz = new Gracz()
            {
                CodaZbudowane = new List<Cod>(),
                Karty = new List<Karta>()
                {
                    cegielnia,karawana,laboratorium,odlewnia,sad,stajnie,warsztattkacki
                },
                Miasto = new Miasto()
                {
                    Coda = new List<Cod>()
                    {
                        new Cod()
                        {
                            Efekty = new List<Efekt>
                            {
                                new Efekt(TypEfektu.Handel, Dzialanie.TaniHandelZLewymSasiadem),
                                new Efekt(TypEfektu.Handel, Dzialanie.TaniHandelZPrawymSasiadem)
                            },
                            Koszt = new List<Surowiec>()
                            {
                                new Surowiec(RodzajSurowca.Drewno, 2)
                            },
                            Poziom = 1
                        },
                        new Cod()
                        {
                            Efekty = new List<Efekt>
                            {
                                new Efekt(TypEfektu.LiczeniePunktow, Dzialanie.DodajPunkty, 5)
                            },
                            Koszt = new List<Surowiec>()
                            {
                                new Surowiec(RodzajSurowca.Kamien, 2)
                            }
                        },
                        new Cod()
                        {
                            Efekty = new List<Efekt>
                            {
                                new Efekt(TypEfektu.JednorazowayEra, Dzialanie.KopiowanieGildiiOdSasiadow)
                            },
                            Koszt = new List<Surowiec>()
                            {
                                new Surowiec(RodzajSurowca.Zloto, 2),
                                new Surowiec(RodzajSurowca.Tkanina, 1)
                            }
                        }
                    },
                    Efekty = new List<Efekt>()
                    {
                        new Efekt(TypEfektu.Produkcja, Dzialanie.DodajDrewno, 1)
                    },
                    Nazwa = "OLYMPIA",
                    Obrazek = (ImageSource)Application.Current.Resources["olympia"],
                },
                Nazwa = "Piotrek",
                Zasoby = new List<Surowiec>(),
                ZetonyWojny = new List<ZetonWojny>()
            };
            var gracz = new Gracz()
            {
                CodaZbudowane = new List<Cod>(),
                Karty = new List<Karta>()
                {
                    cegielnia,karawana,laboratorium,odlewnia,sad,stajnie,warsztattkacki
                },
                Miasto = new Miasto()
                {
                    Coda = new List<Cod>()
                    {
                        new Cod()
                        {
                            Efekty = new List<Efekt>
                            {
                                new Efekt(TypEfektu.Handel, Dzialanie.TaniHandelZLewymSasiadem),
                                new Efekt(TypEfektu.Handel, Dzialanie.TaniHandelZPrawymSasiadem)
                            },
                            Koszt = new List<Surowiec>()
                            {
                                new Surowiec(RodzajSurowca.Drewno, 2)
                            },
                            Poziom = 1
                        },
                        new Cod()
                        {
                            Efekty = new List<Efekt>
                            {
                                new Efekt(TypEfektu.LiczeniePunktow, Dzialanie.DodajPunkty, 5)
                            },
                            Koszt = new List<Surowiec>()
                            {
                                new Surowiec(RodzajSurowca.Kamien, 2)
                            }
                        },
                        new Cod()
                        {
                            Efekty = new List<Efekt>
                            {
                                new Efekt(TypEfektu.JednorazowayEra, Dzialanie.KopiowanieGildiiOdSasiadow)
                            },
                            Koszt = new List<Surowiec>()
                            {
                                new Surowiec(RodzajSurowca.Zloto, 2),
                                new Surowiec(RodzajSurowca.Tkanina, 1)
                            }
                        }
                    },
                    Efekty = new List<Efekt>()
                    {
                        new Efekt(TypEfektu.Produkcja, Dzialanie.DodajDrewno, 1)
                    },
                    Nazwa = "OLYMPIA",
                    Obrazek = (ImageSource)Application.Current.Resources["olympia"],
                },
                Nazwa = "Piotrek",
                Zasoby = new List<Surowiec>(),
                ZetonyWojny = new List<ZetonWojny>()
            };

            Karty = new ObservableCollection<Karta>()
            {
                cegielnia,karawana,laboratorium,odlewnia,sad,stajnie,warsztattkacki
            };
            Karty.Sort(Comparer);
            Gracze = new ObservableCollection<Gracz>()
            {
                Gracz,gracz,Gracz,Gracz,Gracz,Gracz,gracz
            };
        }
    }
    public static class ObservableCollectionExtension
    {
        public static void Sort<T>(this ObservableCollection<T> collection, Comparison<T> comparison)
        {
            var sortableList = new List<T>(collection);
            sortableList.Sort(comparison);

            for (int i = 0; i < sortableList.Count; i++)
            {
                collection.Move(collection.IndexOf(sortableList[i]), i);
            }
        }
        public static void Add<T>(this ObservableCollection<T> collection, T newItem, Comparison<T> comparison)
        {
            for(int i = 0; i< collection.Count; i++)
            {
                int result = comparison.Invoke(newItem, collection[i]);
                if (result < 0)
                {
                    collection.Insert(i, newItem);
                    return;
                }
            }
            collection.Add(newItem);
        }
    }
}