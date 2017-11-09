using Client;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameClient client;
        private ConnectionPage connectionPage;
        private GamePage gamePage;

        public MainWindow()
        {
            InitializeComponent();
            connectionPage = new ConnectionPage();
            connectionPage.setConnectionCallback((host, port, username) =>
            {
                connectionPage.messageBox.Text = "";

                if (username.Length == 0 || host.Length == 0 || port == 0)
                {
                    if (username.Length == 0)
                        connectionPage.messageBox.Text = "Please provide a username\n";
                    if (host.Length == 0)
                        connectionPage.messageBox.Text += "Please provide a host\n";
                    if (port == 0)
                        connectionPage.messageBox.Text += "Please provide a port\n";
                    return;
                }

                client = new GameClient(host, port, username, 2048);
                client.Connect();
                if (client.IsConnected)
                    frame.Content = gamePage = new GamePage();
                
            });
            frame.Content = connectionPage;
        }
    }
}
