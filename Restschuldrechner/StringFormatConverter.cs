// --------------------------------------------------------------------------------------
// <copyright file="StringFormatConverter.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2016 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Restschuldrechner
// </summary>
// --------------------------------------------------------------------------------------
using System;
using System.Globalization;
using Windows.UI.Xaml.Data;
using static System.String;

namespace Restschuldrechner
{
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter == null && value == null)
            {
                return Empty;
            }

            return parameter == null ?
                value.ToString() :
                Format(CultureInfo.CurrentUICulture, parameter.ToString(), value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
}
