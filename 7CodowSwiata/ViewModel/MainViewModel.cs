using GalaSoft.MvvmLight;
using _7CodowSwiata.Model;
using System.Collections.ObjectModel;
using SevenWondersCommon;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using System;

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

        private readonly IDataService _dataService;

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

        //private ICommand _AfterDragCommand;
        public ICommand BeforeDragCommand => new RelayCommand(WybierzKarte);
        public ICommand AfterDragCommand => new RelayCommand<DragDropEffects>(AfterDrag);

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
        public Karta WybranaKarta { get; set; }
        public Ruch Ruch { get; set; }
        public Gracz Gracz { get; set; }
        public Gra Gra { get; set; } = new Gra();//todo jakoś rozpocząć grę
        public ObservableCollection<Gracz> Gracze { get; set; }

        private int _CardW = 140;
        public int CardW
        {
            get => _CardW;
            set
            {
                _CardW = value;
                RaisePropertyChanged();
            }
        } 
        public int CardH {
            get;
            set; } = 210;

        
        public void WybierzKarte()
        {
            WybranaKarta = ZaznaczonaKarta;
            Karty.Remove(ZaznaczonaKarta);
        }
        public void WykonajRuch(TypRuchu ruch)
        {
            CofnijRuch();
            Ruch = new Ruch(Gracz, WybranaKarta, ruch);
            Gra.WykonajRuch(Ruch);
        }
        public void CofnijRuch()
        {
            if (Ruch != null)
                Gra.CofnijRuch();
        }
        public void ZaakceptujRuch()
        {

        }
        public void AfterDrag(DragDropEffects effects)
        {
            if(effects == DragDropEffects.None||effects == DragDropEffects.Link)
                Karty.Add(WybranaKarta);
            WybranaKarta = null;
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(/*IDataService dataService*/)
        {
            var karta = new Karta()
            {
                Efekty = new List<Efekt>()
                    {
                        new Efekt(TypEfektu.Produkcja, Dzialanie.DodajCegle, 1)
                    },
                Koszt = new List<Surowiec>()
                    {
                        new Surowiec(RodzajSurowca.Moneta, 1)
                    },
                Nazwa = "Cegielnia",
                Obrazek = (ImageSource)Application.Current.Resources["cegielnia"],
                Kolor = KolorKarty.Brazowa
            };
            var karta2 = new Karta()
            {
                Efekty = new List<Efekt>()
                    {
                        new Efekt(TypEfektu.Produkcja, Dzialanie.DodajCegle, 1)
                    },
                Koszt = new List<Surowiec>()
                    {
                        new Surowiec(RodzajSurowca.Moneta, 1)
                    },
                Nazwa = "Gej",
                Obrazek = (ImageSource)Application.Current.Resources["cegielnia"],
                Kolor = KolorKarty.Zielona
            };
            Gracz = new Gracz()
            {
                CodaZbudowane = new List<Cod>(),
                Karty = new List<Karta>()
                {
                    karta,karta,karta,karta,karta
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
                    karta,karta,karta2,karta,karta
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
                karta,karta,karta,karta,karta,karta,karta
            };
            Gracze = new ObservableCollection<Gracz>()
            {
                Gracz,gracz,Gracz,Gracz,Gracz,Gracz,gracz
            };
        }
    }
}