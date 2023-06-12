using System;
using ProjetBadgeVirtuel2.ViewModels;
using System.Windows;

namespace ProjetBadgeVirtuel2.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

		
	}
}
