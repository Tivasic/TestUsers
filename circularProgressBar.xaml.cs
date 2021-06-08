using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для circularProgressBar.xaml
    /// </summary>
    public partial class circularProgressBar : UserControl
    {
        public circularProgressBar()
        {
            InitializeComponent();
        }

        public Brush IndicatorBrush
        {
            get { return (Brush)GetValue(IndicatorBrushProperty); }
            set { SetValue(IndicatorBrushProperty, value); }
        }

        public static readonly DependencyProperty IndicatorBrushProperty =
            DependencyProperty.Register("IndicatorBrush", typeof(Brush), typeof(circularProgressBar));

        public Brush BackgroundBrush
        {
            get { return (Brush)GetValue(BackgroundBrushProperty); }
            set { SetValue(BackgroundBrushProperty, value); }
        }

        public static readonly DependencyProperty BackgroundBrushProperty =
            DependencyProperty.Register("BackgroundBrush", typeof(Brush), typeof(circularProgressBar));

        public int ArcThickness
        {
            get { return (int)GetValue(ArcThicknessProperty); }
            set { SetValue(ArcThicknessProperty, value); }
        }

        public static readonly DependencyProperty ArcThicknessProperty =
            DependencyProperty.Register("ArcThickness", typeof(int), typeof(circularProgressBar));

        public int PercentFontSize
        {
            get { return (int)GetValue(PercentFontSizeProperty); }
            set { SetValue(PercentFontSizeProperty, value); }
        }

        public static readonly DependencyProperty PercentFontSizeProperty =
            DependencyProperty.Register("PercentFontSize", typeof(int), typeof(circularProgressBar));

        public string PercentText
        {
            get { return (string)GetValue(PercentTextProperty); }
            set { SetValue(PercentTextProperty, value); }
        }

        public static readonly DependencyProperty PercentTextProperty =
            DependencyProperty.Register("PercentText", typeof(string), typeof(circularProgressBar));

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(circularProgressBar));
    }
    [ValueConversion(typeof(int), typeof(double))]
    public class ValueToAngleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)((int)value * 0.01) * 360;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)((int)value * 360) * 100;
        }
    }

    [ValueConversion(typeof(int), typeof(double))]
    public class ValueToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("{0}{1}", value.ToString(), "%");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
