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

        public MainWindow()
        {
            InitializeComponent();
            connectionPage = new ConnectionPage();
            connectionPage.setConnectionCallback((host, port, username) =>
            {
                client = new GameClient(host, port, username, 2048);
                client.Connect();
            });
            frame.Content = connectionPage;
        }
    }
}
