// --------------------------------------------------------------------------------------
// <copyright file="SimpleTypeConverter.cs" company="André Krämer - Software, Training & Consulting">
//      Copyright (c) 2016 André Krämer http://andrekraemer.de
// </copyright>
// <summary>
//  Restschuldrechner
// </summary>
// --------------------------------------------------------------------------------------
using System;
using System.Globalization;
using Windows.UI.Xaml.Data;
using static System.Convert;

namespace Restschuldrechner
{
    public class SimpleTypeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ChangeType(value, targetType, CultureInfo.CurrentCulture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ChangeType(value, targetType, CultureInfo.CurrentCulture);
        }
    }
}