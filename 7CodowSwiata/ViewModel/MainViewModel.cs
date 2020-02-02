using GalaSoft.MvvmLight;
using _7CodowSwiata.Model;
using System.Collections.ObjectModel;
using SevenWondersCommon;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

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

        public ObservableCollection<Karta> Karty { get; set; }
        public ObservableCollection<Karta> KartyNaKtoreStac { get; set; }
        public Karta WybranaKarta { get; set; }
        public Gracz Gracz { get; set; }
        public ObservableCollection<Gracz> Gracze { get; set; }

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
            Gracz = new Gracz()
            {
                Coda = new List<Cod>(),
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
                ZetonyWojny = new Dictionary<WartoscZetonuWojny, int>()
            };
            
            Karty = new ObservableCollection<Karta>()
            {
                karta,karta,karta,karta,karta,karta,karta
            };
            Gracze = new ObservableCollection<Gracz>()
            {
                Gracz,Gracz,Gracz,Gracz,Gracz,Gracz,Gracz
            };
        }
    }
}