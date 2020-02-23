using _7CodowSwiata.Controls;
using GalaSoft.MvvmLight.Command;
using SevenWondersCommon;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace _7CodowSwiata.Converter
{
    public class DDEventArgsConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            if (value is DDEventArgs)
            {
                var val = (DDEventArgs)value;
                return new AfterDragObject()
                {
                    Rezultat = !(val.Effects == DragDropEffects.None),
                    Karta = val.Data as Karta
                };
            }
            if (value is DragEventArgs)
            {
                var val = (DragEventArgs)value;
                return new AfterDragObject()
                {
                    Rezultat = !(val.Effects == DragDropEffects.None),
                    Karta = (Karta)val.Data.GetData("Data")
                };
            }
            return null;
        }
    }
    public class AfterDragObject
    {
        public Karta Karta { get; set; }
        public bool Rezultat { get; set; }
    }
}
