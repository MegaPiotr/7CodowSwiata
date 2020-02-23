using _7CodowSwiata.Controls;
using GalaSoft.MvvmLight.Command;
using SevenWondersCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7CodowSwiata.Converter
{
    public class BeforeDragEventArgsConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            var val = value as DDEventArgs;
            return val?.Data as Karta;
        }
    }
}
