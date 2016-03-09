﻿// Copyright © 2010 James Galasyn 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

using Emotiv;
using System.Diagnostics;
using System.Globalization;

namespace EmoEngineControlLibrary
{
    [ValueConversion( typeof( EdkDll.EE_EEG_ContactQuality_t ), typeof( Brush ) )]
    class EeContactQualityToBrushConverter : IValueConverter
    {
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture )
        {
            Brush b = null;

            // Only apply the conversion if value is assigned and
            // is of type bool.
            if( value != null &&
                value.GetType() == typeof( EdkDll.EE_EEG_ContactQuality_t ) )
            {
                EdkDll.EE_EEG_ContactQuality_t contactQuality = (EdkDll.EE_EEG_ContactQuality_t)value;
                switch( contactQuality )
                {
                    case EdkDll.EE_EEG_ContactQuality_t.EEG_CQ_NO_SIGNAL:
                        {
                            b = Brushes.Black;
                            break;
                        }

                    case EdkDll.EE_EEG_ContactQuality_t.EEG_CQ_VERY_BAD:
                        {
                            b = Brushes.Red;
                            break;
                        }

                    case EdkDll.EE_EEG_ContactQuality_t.EEG_CQ_POOR:
                        {
                            b = Brushes.Orange;
                            break;
                        }

                    case EdkDll.EE_EEG_ContactQuality_t.EEG_CQ_FAIR:
                        {
                            b = Brushes.Yellow;
                            break;
                        }

                    case EdkDll.EE_EEG_ContactQuality_t.EEG_CQ_GOOD:
                        {
                            b = Brushes.Green;
                            break;
                        }

                    default:
                        {
                            Trace.Assert( false, "Unknown EE_EEG_ContactQuality_t value" );
                            break;
                        }
                }
            }

            return b;
        }

        // Not used.
        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture )
        {
            return null;
        }
    }
}
