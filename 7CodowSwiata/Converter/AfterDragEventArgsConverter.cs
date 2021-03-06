﻿using _7CodowSwiata.Controls;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _7CodowSwiata.Converter
{
    public class AfterDragEventArgsConverter : IEventArgsConverter
    {
        public object Convert(object value, object parameter)
        {
            var val = value as DDEventArgs;
            if (val != null)
                return !(val.Effects == DragDropEffects.None);
            return false;
        }
    }
}
