using _7CodowSwiata.Controls;
using GalaSoft.MvvmLight.Command;
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
    public class AfterDragEventArgsConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            var val = value as AfterDragEventArgs;
            return val.Effects;
        }
    }
}
