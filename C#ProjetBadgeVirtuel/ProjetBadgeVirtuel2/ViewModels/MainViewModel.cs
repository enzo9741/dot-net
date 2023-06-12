using System;
using ProjetBadgeVirtuel2.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjetBadgeVirtuel2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private TcpSocket tcpSocket = new TcpSocket();
        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                if (value != _message)
                {
                    _message = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void SendMessage()
        {
            tcpSocket.SendMessage(Message);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
