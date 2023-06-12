using System.Windows;
using ProjetBadge.ViewModels;

namespace ProjetBadge.Views
{
    public partial class BadgeVirtuelView : Window
    {
        public BadgeVirtuelView()
        {
            InitializeComponent();
            DataContext = new BadgeVirtuelViewModel(); ;
        }
    }
}
