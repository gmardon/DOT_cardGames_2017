using System;
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

namespace Poker.Client
{
    /// <summary>
    /// Interaction logic for ConnectionPage.xaml
    /// </summary>
    public partial class ConnectionPage : Page
    {
        public delegate void onConnection(string host, int port, string username);

        private onConnection callback = null;

        public ConnectionPage()
        {
            InitializeComponent();
        }

        public void setConnectionCallback(onConnection callback)
        {
            this.callback = callback;
        }

        private void ConnectionButton_OnClick(object sender, RoutedEventArgs e)
        {
            callback?.Invoke(this.host.Text, int.Parse(this.port.Text), this.username.Text);
        }
    }
}
