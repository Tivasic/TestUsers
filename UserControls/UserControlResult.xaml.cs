﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestUsers
{
    /// <summary>
    /// Логика взаимодействия для UserControlResult.xaml
    /// </summary>
    public partial class UserControlResult : UserControl
    {
        public UserControlResult()
        {
            InitializeComponent();
        }

        private void OpenMainWindowButton_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc;
            usc = new UserControlMainPage();
            GridMain.Children.Add(usc);
        }
    }
}