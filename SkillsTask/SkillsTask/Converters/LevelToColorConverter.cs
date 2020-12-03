using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SkillsTask.Converters
{
    public class LevelToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var level = (int)value;
            
            if(level <= 50)
            {
                return Color.Red;
            }
            else if (level > 50 && level <= 70)
            {
                return Color.Yellow;

            }
            else if (level > 70 && level <= 89)
            {
                return Color.Blue;

            }
            else
            {
                return Color.Green;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
