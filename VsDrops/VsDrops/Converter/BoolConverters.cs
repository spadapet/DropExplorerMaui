using System;
using System.Globalization;

namespace VsDrop.Converter;

public class InverseBoolConverter : ValueConverter
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return !(bool)value;
    }
}