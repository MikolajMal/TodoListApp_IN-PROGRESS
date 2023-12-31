﻿using DatabaseSQLTodoListApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DatabaseSQLTodoListApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow();

            Window loginWindow = new UserLoginWindow();
            UserLoginViewModel userLoginViewModel = new UserLoginViewModel(loginWindow);
            loginWindow.DataContext = userLoginViewModel;
            loginWindow.ShowDialog();

            if (userLoginViewModel.CloseApp)
            {
                Application.Current.Shutdown();
                return;
            }

            MainWindow.DataContext = new MainViewModel(MainWindow, userLoginViewModel.ConnectionString);
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
