using SevenWondersCommon;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace _7CodowSwiata.Converter
{
    public class ColorEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is null) return Color.FromRgb(0, 0, 0);
            if (value is KolorKarty)
            {
                switch((KolorKarty)value)
                {
                    case KolorKarty.Brazowa:
                        return Color.FromRgb(60, 20, 15);
                    case KolorKarty.Czerwona:
                        return Color.FromRgb(160, 20, 10);
                    case KolorKarty.Fioletowa:
                        return Color.FromRgb(60, 10, 110);
                    case KolorKarty.Niebieska:
                        return Color.FromRgb(40, 140, 240);
                    case KolorKarty.Szara:
                        return Color.FromRgb(160, 180, 200);
                    case KolorKarty.Zielona:
                        return Color.FromRgb(20, 120, 40);
                    case KolorKarty.Zolta:
                        return Color.FromRgb(210, 200, 30);
                }
            }
            return Color.FromRgb(0, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
