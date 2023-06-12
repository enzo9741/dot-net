using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// MainViewModel.cs
using ProjetBadge.Models;
using System.Windows.Input;
using System.ComponentModel;
using System.ComponentModel;
using ProjetBadge.Models;
using ProjetBadge.Commands;


namespace ProjetBadge.ViewModels
{
	
    public class BadgeVirtuelViewModel : INotifyPropertyChanged
    {
        private TcpSocket _tcpSocket = new TcpSocket();
        public event PropertyChangedEventHandler PropertyChanged;

        // Exemple de propriété pour bind avec la vue
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged("Message");
                }
            }
        }

        // Exemple de commande pour bind avec la vue
        public ICommand SendMessageCommand { get; private set; }

        public BadgeVirtuelViewModel()
        {
            SendMessageCommand = new RelayCommand(SendMessage, CanSendMessage);
        }

        private void SendMessage()
        {
            _tcpSocket.SendMessage(Message);
        }

        private bool CanSendMessage()
        {
            return !string.IsNullOrEmpty(Message);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
