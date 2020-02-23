using SevenWondersCommon;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace _7CodowSwiata.Converter
{
    public class TypRuchuToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TypRuchu? typ = (TypRuchu?)value;
            TypRuchu dozwolonyTyp = (TypRuchu)parameter;
            return typ == dozwolonyTyp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
